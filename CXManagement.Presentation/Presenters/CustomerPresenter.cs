using CXManagement.Application.DTOs.CX_Customer;
using CXManagement.Application.DTOs.CX_Customer_AppKeyword_Value;
using CXManagement.Presentation.Services.Http;
using CXManagement.Presentation.Views.Interfaces;

namespace CXManagement.Presentation.Presenters
{
    public class CustomerPresenter
    {
        private readonly CustomerService _service;
        private readonly ApplicationService _applicationService;
        private readonly KeywordService _keywordService;

        private ICustomerView _view;

        public CustomerPresenter(
            CustomerService service,
            ApplicationService applicationService,
            KeywordService keywordService)
        {
            _service = service;
            _applicationService = applicationService;
            _keywordService = keywordService;

        }

        public void SetView(ICustomerView view)
        {
            _view = view;
        }

        public async Task LoadCustomersAsync()
        {
            try
            {
                var customers = await _service.GetAllAsync();
                _view.ShowCustomers(customers);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Error loading customers: {ex.Message}");
            }
        }

        public async Task LoadCustomerByIdAsync(int id)
        {
            try
            {
                var customer = await _service.GetByIdAsync(id);
                if (customer != null)
                    _view.ShowCustomer(customer);
                else
                    _view.ShowError("Customer not found.");
            }
            catch (Exception ex)
            {
                _view.ShowError($"Error loading customer: {ex.Message}");
            }
        }

        public async Task LoadCustomerAppKeywordValueViewAsync(int customerId)
        {
            try
            {
                var customerAppKeywordValueView = await _service.GetCustomerAppKeywordValueViewAsync(customerId);

                if (customerAppKeywordValueView != null)
                    _view.ShowCustomerAppKeywordValueView(customerAppKeywordValueView);
                else
                    _view.ShowError("Customer not found.");
            }
            catch (Exception ex)
            {
                _view.ShowError($"Error loading LoadCustomerAppKeywordValueView: {ex.Message}");
            }
        }

        public async Task<int> CreateCustomerAsync(CreateCustomerDto dto)
        {
            try
            {
                int customerId = await _service.CreateAsync(dto);
                return customerId;
            }
            catch (Exception ex)
            {
                _view.ShowError($"Error creating customer: {ex.Message}");
                return -1;
            }
        }

        public async Task<bool> UpdateCustomerAsync(UpdateCustomerDto dto)
        {
            try
            {
                return await _service.UpdateAsync(dto);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Error updating customer: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            try
            {
                var success = await _service.DeleteAsync(id);
                if (success)
                    await LoadCustomersAsync();
                else
                    _view.ShowError("Failed to delete customer.");

                return success;
            }
            catch (Exception ex)
            {
                _view.ShowError($"Error deleting customer: {ex.Message}");
                return false;
            }
        }

        public async Task LoadApplicationsWithKeywordsAsync()
        {
            try
            {
                var applications = await _applicationService.GetAllApplicationKeywordsAsync();
                _view.ShowApplications(applications);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Error loading applications: {ex.Message}");
            }
        }

        public async Task LoadKeywordsForApplicationAsync(int applicationId)
        {
            try
            {
                var keywords = await _keywordService.GetAllKeywordsByApplicationIdAsync(applicationId);
                _view.ShowKeywords(keywords);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Error loading keywords: {ex.Message}");
            }
        }

        public async Task<bool> CreateCustomerAppKeywordValueAsync(CreateCustomerAppKeywordValueDto valueDto)
        {
            try
            {
                return await _service.CreateCustomerAppKeywordValueAsync(valueDto);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Error saving keyword value: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateCustomerKeywordValueAsync(UpdateCustomerAppKeywordValueDto dto)
        {
            try
            {
                return await _service.UpdateCustomerAppKeywordValueAsync(dto);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Error updating keyword value: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteCustomerKeywordValueAsync(int id)
        {
            try
            {
                return await _service.DeleteCustomerAppKeywordValueAsync(id);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Error deleting keyword value: {ex.Message}");
                return false;
            }
        }
    }
}
