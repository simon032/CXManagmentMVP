using CXManagement.Application.DTOs.CX_Application;
using CXManagement.Application.DTOs.CX_Application_Keyword;
using CXManagement.Application.DTOs.CX_Keyword;
using CXManagement.Presentation.Views.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CXManagement.Presentation.Pages.Keywords
{
    public partial class KeywordForm : ComponentBase, IKeywordView
    {
        [Inject] private KeywordPresenter Presenter { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        [Parameter] public int? Id { get; set; }

        protected KeywordDto Model { get; set; } = new KeywordDto();
        protected bool IsLoading { get; set; } = true;
        protected string ErrorMessage { get; set; }
        protected bool IsEdit => Id.HasValue;
        protected List<ApplicationDto> Applications { get; set; } = new();
        private int? SelectedApplicationId { get; set; }
        private List<ApplicationDto> FilteredApplications => Applications
            .Where(app => Model.ApplicationKeywords == null || !Model.ApplicationKeywords.Any(ak => ak.CXASID == app.CXAID)).ToList();
        private bool IsProcessingAppAssignment = false;

        protected override async Task OnInitializedAsync()
        {
            Presenter.SetView(this);
            await Presenter.LoadApplicationsAsync();

            if (IsEdit)
            {
                await Presenter.LoadKeywordByIdAsync(Id.Value);
                StateHasChanged();
            }
            else
            {
                IsLoading = false;
            }
        }

        public void ShowKeyword(KeywordDto keyword)
        {
            Model = keyword ?? new KeywordDto();
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

        public void ShowKeywords(IEnumerable<KeywordDto> keywords)
        {
            // Not needed here; implemented for IKeywordView compatibility.
        }

        protected async Task HandleValidSubmit()
        {
            ErrorMessage = null;

            if (IsEdit)
            {
                await Presenter.LoadKeywordByIdAsync(Model.CXKeywordID);
                StateHasChanged();
                var success = await Presenter.UpdateKeywordAsync(new UpdateKeywordDto
                {
                    CXKeywordID = Model.CXKeywordID,
                    CXKeywordName = Model.CXKeywordName,
                    CXKeywordDescription = Model.CXKeywordDescription,
                    CXKeywordDataType = Model.CXKeywordDataType,
                    CXKeywordScoringFormula = Model.CXKeywordScoringFormula,
                    CXKeywordIsActive = Model.CXKeywordIsActive,
                    ModifyAt = DateTime.UtcNow,
                    ModifyBy = 1, // Replace with actual user ID

                });

                if (success)
                {
                    NavigationManager.NavigateTo("/keywords");
                }
                else
                {
                    ShowError("Failed to update keyword.");
                }
            }
            else
            {
                var newId = await Presenter.CreateKeywordAsync(new CreateKeywordDto
                {
                    CXKeywordName = Model.CXKeywordName,
                    CXKeywordDescription = Model.CXKeywordDescription,
                    CXKeywordDataType = Model.CXKeywordDataType,
                    CXKeywordScoringFormula = Model.CXKeywordScoringFormula,
                    CXKeywordIsActive = Model.CXKeywordIsActive,
                    CreateAt = DateTime.UtcNow,
                    CreateBy = 1, // Replace with actual user ID

                });

                if (newId > 0)
                {
                    Id = newId;
                    await Presenter.LoadKeywordByIdAsync(newId);
                    StateHasChanged(); // Refresh the UI
                }
                else
                {
                    ShowError("Failed to create keyword.");
                }
            }
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/keywords");
        }

        public void ShowApplications(IEnumerable<ApplicationDto> applications)
        {
            Applications = applications.ToList();
            StateHasChanged();
        }
        protected async Task AddApplicationKeyword()
        {
            if (SelectedApplicationId.HasValue && Model.CXKeywordID > 0)
            {
                IsProcessingAppAssignment = true;
                StateHasChanged();
                var success = await Presenter.AddApplicationKeywordAsync(new CreateApplicationKeywordDto
                {
                    CXASID = SelectedApplicationId.Value,
                    CXKeywordID = Model.CXKeywordID,
                    CXAKWeight = 1 // or another default value
                });

                if (success)
                {
                    await Presenter.LoadKeywordByIdAsync(Model.CXKeywordID); // refresh assigned apps
                    SelectedApplicationId = null;
                }
                else
                {
                    ShowError("Failed to assign application.");
                }
                IsProcessingAppAssignment = false;
                StateHasChanged();
            }
        }

        protected async Task RemoveApplicationKeyword(int? applicationId)
        {
            if (Model.CXKeywordID > 0)
            {
                IsProcessingAppAssignment = true;
                StateHasChanged();
                var success = await Presenter.DeleteApplicationKeywordAsync(Model.CXKeywordID, (int)applicationId);
                if (success)
                {
                    await Presenter.LoadKeywordByIdAsync(Model.CXKeywordID); // refresh assigned apps
                }
                else
                {
                    ShowError("Failed to remove application.");
                }
                IsProcessingAppAssignment = false;
                StateHasChanged();

            }
        }

    }
}
