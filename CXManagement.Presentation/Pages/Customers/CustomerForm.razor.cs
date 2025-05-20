using CXManagement.Application.DTOs.CX_Application;
using CXManagement.Application.DTOs.CX_Customer;
using CXManagement.Application.DTOs.CX_Customer_AppKeyword_Value;
using CXManagement.Application.DTOs.CX_Keyword;
using CXManagement.Presentation.Presenters;
using CXManagement.Presentation.Views.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CXManagement.Presentation.Pages.Customers
{
    public partial class CustomerForm : ComponentBase, ICustomerView
    {
        [Inject] private CustomerPresenter Presenter { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        [Parameter] public int? Id { get; set; }

        protected CustomerDto Model { get; set; } = new();
        protected bool IsLoading { get; set; } = true;
        protected string ErrorMessage { get; set; }
        protected bool IsEdit => Id.HasValue;

        protected List<ApplicationDto> Applications { get; set; } = new();
        protected List<KeywordDto> Keywords { get; set; } = new();
        protected List<CustomerAppKeywordValueViewDto> CustomerAppKeywordValueView { get; set; } = new();

        protected int? SelectedApplicationId { get; set; }
        protected int? SelectedKeywordId { get; set; }

        protected CreateCustomerAppKeywordValueDto CustomerKeywordValueModel { get; set; } = new();

        private bool IsEditingKeywordValue = false;
        private int? EditingRecordId;
        private CustomerAppKeywordValueViewDto? EditingCustomerKeywordValueModel;


        private async void StartEdit(CustomerAppKeywordValueViewDto record)
        {
            EditingRecordId = record.CXCAKVID;
            IsEditingKeywordValue = true;

            //SelectedApplicationId = null;
            //SelectedKeywordId = null;


            EditingCustomerKeywordValueModel = new CustomerAppKeywordValueViewDto
            {
                CXCAKVID = record.CXCAKVID,
                CXCustomerID = record.CXCustomerID,
                CXASKID = record.CXASKID,
                CXCAKVValueString = record.CXCAKVValueString,
                CXCAKVAssignedDate = record.CXCAKVAssignedDate,
                ApplicationName = record.ApplicationName,
                KeywordName = record.KeywordName
            };

            await Presenter.LoadCustomerByIdAsync(Id.Value);
            await Presenter.LoadCustomerAppKeywordValueViewAsync(Id.Value);


            StateHasChanged();
        }

        private void CancelEdit()
        {
            IsEditingKeywordValue = false;
            EditingRecordId = null;
            EditingCustomerKeywordValueModel = null;
        }
        private async Task HandleEditKeywordValueSubmit()
        {
            if (EditingCustomerKeywordValueModel is not null)
            {
                var dto = new UpdateCustomerAppKeywordValueDto()
                {
                    CXCAKVID = EditingCustomerKeywordValueModel.CXCAKVID,
                    CXCustomerID = EditingCustomerKeywordValueModel.CXCustomerID,
                    CXASKID = EditingCustomerKeywordValueModel.CXASKID,
                    CXCAKVValueString = EditingCustomerKeywordValueModel.CXCAKVValueString,
                    CXCAKVAssignedDate = EditingCustomerKeywordValueModel.CXCAKVAssignedDate,
                    ModifyAt = DateTime.UtcNow,
                    ModifyBy = 1

                };
                // Call API or presenter to save the updated value
                await Presenter.UpdateCustomerKeywordValueAsync(dto);
                IsEditingKeywordValue = false;
                EditingRecordId = null;
                EditingCustomerKeywordValueModel = null;

                await Presenter.LoadCustomerByIdAsync(Id.Value);
                await Presenter.LoadCustomerAppKeywordValueViewAsync(Id.Value);


                StateHasChanged();
            }
        }
        private async Task DeleteKeywordValueAsync(int id)
        {

            var success = await Presenter.DeleteCustomerKeywordValueAsync(id);
            if (success)
            {
                await Presenter.LoadCustomerByIdAsync(Model.CXCustomerID); // refresh assigned apps
                await Presenter.LoadCustomerAppKeywordValueViewAsync(Id.Value);
            }
            else
            {
                ShowError("Failed to remove CustomerKeywordValue.");
            }


            // await LoadCustomerData();
            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            Presenter.SetView(this);

            await Presenter.LoadApplicationsWithKeywordsAsync();

            if (IsEdit)
            {
                await Presenter.LoadCustomerByIdAsync(Id.Value);
                await Presenter.LoadCustomerAppKeywordValueViewAsync(Id.Value);
                StateHasChanged();
            }
            else
            {
                IsLoading = false;
            }
        }

        public void ShowCustomer(CustomerDto customer)
        {
            Model = customer ?? new CustomerDto();
            ErrorMessage = null;
            IsLoading = false;
            StateHasChanged();
        }

        public void ShowCustomers(IEnumerable<CustomerDto> customers)
        {
            // Not used
        }

        public void ShowError(string message)
        {
            ErrorMessage = message;
            IsLoading = false;
            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {
            ErrorMessage = null;

            if (IsEdit)
            {
                var success = await Presenter.UpdateCustomerAsync(new UpdateCustomerDto
                {
                    CXCustomerID = Model.CXCustomerID,
                    CXCustomerFullName = Model.CXCustomerFullName,
                    CXCustomerEmail = Model.CXCustomerEmail,
                    CXCustomerPhone = Model.CXCustomerPhone,
                    ModifyAt = DateTime.UtcNow,
                    ModifyBy = 1 // Replace with actual user ID
                });

                if (!success)
                {
                    ShowError("Failed to update customer.");
                }
                else
                {
                    NavigationManager.NavigateTo("/customers");
                }
            }
            else
            {
                var newId = await Presenter.CreateCustomerAsync(new CreateCustomerDto
                {
                    CXCustomerFullName = Model.CXCustomerFullName,
                    CXCustomerEmail = Model.CXCustomerEmail,
                    CXCustomerPhone = Model.CXCustomerPhone,
                    CreateAt = DateTime.UtcNow,
                    CreateBy = 1 // Replace with actual user ID
                });

                if (newId > 0)
                {
                    Id = newId;
                    await Presenter.LoadCustomerByIdAsync(newId);
                    StateHasChanged(); // Refresh UI to enable assigning keyword values
                }
                else
                {
                    ShowError("Failed to create customer.");
                }
            }
        }

        protected async Task OnApplicationChanged(ChangeEventArgs e)
        {
            SelectedApplicationId = int.TryParse(e.Value?.ToString(), out var appId) ? appId : null;
            //SelectedKeywordId = null;
            //Keywords.Clear();
            //CustomerKeywordValueModel = new();
            await Presenter.LoadKeywordsForApplicationAsync(SelectedApplicationId.Value);
        }

        protected void OnKeywordChanged(ChangeEventArgs e)
        {
            SelectedKeywordId = int.TryParse(e.Value?.ToString(), out var keywordId) ? keywordId : null;
            //CustomerKeywordValueModel = new();
        }

        protected async Task HandleKeywordValueSubmit()
        {
            if (!Id.HasValue || !SelectedApplicationId.HasValue || !SelectedKeywordId.HasValue)
            {
                ShowError("Please select an application and keyword, and ensure a customer is loaded.");
                return;
            }
            var appKeyword = Applications
            .FirstOrDefault(a => a.CXAID == SelectedApplicationId.Value)?
            .ApplicationKeywords?
            .FirstOrDefault(k => k.CXKeywordID == SelectedKeywordId.Value);

            if (appKeyword == null)
            {
                ShowError("Invalid application-keyword selection.");
                return;
            }

            var success = await Presenter.CreateCustomerAppKeywordValueAsync(new CreateCustomerAppKeywordValueDto
            {
                CXCustomerID = Id.Value,
                CXASKID = appKeyword.CXAKID,
                CXCAKVValueString = CustomerKeywordValueModel.CXCAKVValueString,
                CXCAKVAssignedDate = DateTime.UtcNow,
                CreateAt = DateTime.UtcNow,
                CreateBy = 1 // Replace with actual user ID

            });

            if (!success)
            {
                ShowError("Failed to save keyword value.");
            }
            else
            {
                CustomerKeywordValueModel = new();
                SelectedKeywordId = null;
                SelectedApplicationId = null;

                await Presenter.LoadCustomerByIdAsync(Id.Value);
                await Presenter.LoadCustomerAppKeywordValueViewAsync(Id.Value);
                CustomerKeywordValueModel = new();
                SelectedApplicationId = null;
                SelectedKeywordId = null;
                Keywords.Clear();
                StateHasChanged();
            }

        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/customers");
        }

        public void ShowApplications(IEnumerable<ApplicationDto> applications)
        {
            Applications = applications.ToList();
            StateHasChanged();
        }
        public void ShowKeywords(IEnumerable<KeywordDto> keywords)
        {
            Keywords = keywords.ToList();
            StateHasChanged();
        }

        public void ShowCustomerAppKeywordValueView(List<CustomerAppKeywordValueViewDto> dto)
        {
            CustomerAppKeywordValueView = dto.ToList();
            StateHasChanged();
        }
    }
}
