using CXManagement.Application.DTOs.CX_Application;
using CXManagement.Presentation.Presenters;
using CXManagement.Presentation.Views.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CXManagement.Presentation.Pages.Applications
{
    public partial class ApplicationForm : ComponentBase, IApplicationView
    {
        [Inject] private ApplicationPresenter Presenter { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        [Parameter] public int? Id { get; set; }

        protected ApplicationDto Model { get; set; } = new ApplicationDto();
        protected bool IsLoading { get; set; } = true;
        protected string ErrorMessage { get; set; }
        protected bool IsEdit => Id.HasValue;

        protected override async Task OnInitializedAsync()
        {
            Presenter.SetView(this);

            if (IsEdit)
            {
                await Presenter.LoadApplicationByIdAsync(Id.Value);
            }
            else
            {
                IsLoading = false;
            }
        }

        public void ShowApplication(ApplicationDto application)
        {
            Model = application ?? new ApplicationDto();
            ErrorMessage = null;
            IsLoading = false;
            StateHasChanged();
        }

        public void ShowError(string message)
        {
            ErrorMessage = message;
            IsLoading = false;
            StateHasChanged();
        }

        public void ShowApplications(IEnumerable<ApplicationDto> applications)
        {
            // Not needed in this form; implemented for IApplicationView compatibility.
        }

        protected async Task HandleValidSubmit()
        {
            ErrorMessage = null;

            if (IsEdit)
            {
                var success = await Presenter.UpdateApplicationAsync(new UpdateApplicationDto
                {
                    CXAID = Model.CXAID,
                    CXAName = Model.CXAName,
                    ModifyAt = DateTime.UtcNow,
                    ModifyBy = 1 // Replace with actual user id
                });

                if (success)
                {
                    NavigationManager.NavigateTo("/applications");
                }
                else
                {
                    ShowError("Failed to update application.");
                }
            }
            else
            {
                var newId = await Presenter.CreateApplicationAsync(new CreateApplicationDto
                {
                    CXAName = Model.CXAName,
                    CreateAt = DateTime.UtcNow,
                    CreateBy = 1 // Replace with actual user id
                });

                if (newId > 0)
                {
                    NavigationManager.NavigateTo("/applications");
                }
                else
                {
                    ShowError("Failed to create application.");
                }
            }
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/applications");
        }
    }
}
