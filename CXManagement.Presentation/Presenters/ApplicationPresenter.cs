using CXManagement.Application.DTOs.CX_Application;
using CXManagement.Presentation.Services.Http;
using CXManagement.Presentation.Views.Interfaces;

namespace CXManagement.Presentation.Presenters
{
    public class ApplicationPresenter
    {
        private readonly ApplicationService _service;
        private IApplicationView _view;

        public ApplicationPresenter(ApplicationService service)
        {
            _service = service;
        }

        public void SetView(IApplicationView view)
        {
            _view = view;
        }

        public async Task LoadApplicationsAsync()
        {
            try
            {
                var applications = await _service.GetAllApplicationsAsync();
                _view.ShowApplications(applications);
            }
            catch (System.Exception ex)
            {
                _view.ShowError($"Error loading applications: {ex.Message}");
            }
        }

        public async Task LoadApplicationByIdAsync(int id)
        {
            try
            {
                var application = await _service.GetApplicationByIdAsync(id);
                if (application != null)
                    _view.ShowApplication(application);
                else
                    _view.ShowError("Application not found.");
            }
            catch (System.Exception ex)
            {
                _view.ShowError($"Error loading application: {ex.Message}");
            }
        }

        public async Task<bool> DeleteApplicationAsync(int id)
        {
            try
            {
                var success = await _service.DeleteApplicationAsync(id);
                if (success)
                    await LoadApplicationsAsync();
                else
                    _view.ShowError("Failed to delete application.");

                return success;
            }
            catch (System.Exception ex)
            {
                _view.ShowError($"Error deleting application: {ex.Message}");
                return false;
            }
        }

        public async Task<int> CreateApplicationAsync(CreateApplicationDto dto)
        {
            try
            {
                return await _service.CreateApplicationAsync(dto);
            }
            catch (System.Exception ex)
            {
                _view.ShowError($"Error creating application: {ex.Message}");
                return -1;
            }
        }

        public async Task<bool> UpdateApplicationAsync(UpdateApplicationDto dto)
        {
            try
            {
                return await _service.UpdateApplicationAsync(dto);
            }
            catch (System.Exception ex)
            {
                _view.ShowError($"Error updating application: {ex.Message}");
                return false;
            }
        }
    }
}
