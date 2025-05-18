using CXManagement.Application.DTOs.CX_Application_Keyword;
using CXManagement.Application.DTOs.CX_Keyword;
using CXManagement.Presentation.Services.Http;
using CXManagement.Presentation.Views.Interfaces;

namespace CXManagement.Presentation
{
    public class KeywordPresenter
    {
        private readonly KeywordService _service;
        private IKeywordView _view;
        private readonly ApplicationService _applicationService;

        public KeywordPresenter(KeywordService service, ApplicationService applicationService)
        {
            _service = service;
            _applicationService = applicationService;
        }

        public void SetView(IKeywordView view)
        {
            _view = view;
        }

        public async Task LoadKeywordsAsync()
        {
            try
            {
                var keywords = await _service.GetAllAsync();
                _view.ShowKeywords(keywords);
            }
            catch (System.Exception ex)
            {
                _view.ShowError($"Error loading keywords: {ex.Message}");
            }
        }

        public async Task LoadKeywordByIdAsync(int id)
        {
            try
            {
                var keyword = await _service.GetByIdAsync(id);
                if (keyword != null)
                    _view.ShowKeyword(keyword);
                else
                    _view.ShowError("Keyword not found.");
            }
            catch (System.Exception ex)
            {
                _view.ShowError($"Error loading keyword: {ex.Message}");
            }
        }

        public async Task<int> CreateKeywordAsync(CreateKeywordDto model)
        {
            try
            {
                int keywordId = await _service.CreateAsync(model);
                //if (keywordId > 0)
                //{
                //    // Now associate it with selected application
                //    await _service.CreateApplicationKeywordAsync(new CreateApplicationKeywordDto
                //    {
                //        CXASID = model.CXAID,
                //        CXKeywordID = keywordId,
                //        CXAKWeight = model.CXAKWeight
                //    });
                //}
                return keywordId;
            }
            catch (Exception ex)
            {
                _view.ShowError($"Error creating keyword: {ex.Message}");
                return -1;
            }
        }

        public async Task<bool> UpdateKeywordAsync(UpdateKeywordDto model)
        {
            try
            {
                return await _service.UpdateAsync(model);
            }
            catch (System.Exception ex)
            {
                _view.ShowError($"Error updating keyword: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteKeywordAsync(int id)
        {
            await _service.DeleteAsync(id);
            await LoadKeywordsAsync();

            try
            {
                var success = await _service.DeleteAsync(id);
                if (success)
                    await LoadKeywordsAsync();
                else
                    _view.ShowError("Failed to delete keyword.");

                return success;
            }
            catch (System.Exception ex)
            {
                _view.ShowError($"Error deleting keyword: {ex.Message}");
                return false;
            }
        }

        public async Task LoadApplicationsAsync()
        {
            try
            {
                var applications = await _applicationService.GetAllApplicationsAsync();
                _view.ShowApplications(applications);
            }
            catch (Exception ex)
            {
                _view.ShowError("Failed to load applications: " + ex.Message);
            }
        }
        public async Task<bool> AddApplicationKeywordAsync(CreateApplicationKeywordDto dto)
        {
            try
            {
                return await _service.CreateApplicationKeywordAsync(dto);
            }
            catch (Exception ex)
            {
                _view.ShowError("Failed to assign application: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteApplicationKeywordAsync(int keywordId, int applicationId)
        {
            try
            {
                return await _service.DeleteApplicationKeywordAsync(keywordId, applicationId);
            }
            catch (Exception ex)
            {
                _view.ShowError("Failed to delete application assignment: " + ex.Message);
                return false;
            }
        }


    }
}
