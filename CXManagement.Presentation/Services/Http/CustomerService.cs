using CXManagement.Application.DTOs.CX_Application;
using CXManagement.Application.DTOs.CX_Customer;
using CXManagement.Application.DTOs.CX_Customer_AppKeyword_Value;
using CXManagement.Application.DTOs.CX_Keyword;
using CXManagement.Application.UseCases.Customer;
using CXManagement.Application.UseCases.CustomerAppKeywordValue;
using System.Net.Http.Json;

namespace CXManagement.Presentation.Services.Http
{
    public class CustomerService
    {
        private readonly HttpClient _http;

        public CustomerService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<IEnumerable<CustomerDto>>("api/customer")
                   ?? new List<CustomerDto>();
        }

        public async Task<CustomerDto> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<CustomerDto>($"api/customer/{id}");
        }

        public async Task<int> CreateAsync(CreateCustomerDto model)
        {
            var command = new CreateCustomerCommand
            {
                Customer = model
            };

            var response = await _http.PostAsJsonAsync("api/customer", command);
            response.EnsureSuccessStatusCode();

            var customerId = await response.Content.ReadFromJsonAsync<int>();
            return customerId;
        }

        public async Task<bool> UpdateAsync(UpdateCustomerDto model)
        {
            var response = await _http.PutAsJsonAsync($"api/customer/{model.CXCustomerID}", new { Customer = model });
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/customer/{id}");
            return response.IsSuccessStatusCode;
        }

        // Load Applications that have Keywords (used in dropdown)
        public async Task<IEnumerable<ApplicationDto>> GetApplicationsWithKeywordsAsync()
        {
            return await _http.GetFromJsonAsync<IEnumerable<ApplicationDto>>("api/application/with-keywords")
                   ?? new List<ApplicationDto>();
        }

        // Load Keywords for a given ApplicationId
        public async Task<IEnumerable<KeywordDto>> GetKeywordsByApplicationIdAsync(int applicationId)
        {
            return await _http.GetFromJsonAsync<IEnumerable<KeywordDto>>($"api/keyword/by-application/{applicationId}")
                   ?? new List<KeywordDto>();
        }

        // Submit a CustomerAppKeywordValue
        public async Task<bool> CreateCustomerAppKeywordValueAsync(CreateCustomerAppKeywordValueDto dto)
        {
            var command = new CreateCustomerAppKeywordValueCommand { CustomerAppKeywordValue = dto };
            var response = await _http.PostAsJsonAsync("api/customerappkeywordvalue", command);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<CustomerAppKeywordValueViewDto>> GetCustomerAppKeywordValueViewAsync(int customerId)
        {
            return await _http.GetFromJsonAsync<List<CustomerAppKeywordValueViewDto>>($"api/CustomerAppKeywordValue/GetCustomerAppKeywordValueViewByCustomerId/{customerId}")
                   ?? new List<CustomerAppKeywordValueViewDto>();
        }

        public async Task<bool> UpdateCustomerAppKeywordValueAsync(UpdateCustomerAppKeywordValueDto dto)
        {
            var command = new UpdateCustomerAppKeywordValueCommand
            {
                CustomerAppKeywordValue = dto
            };

            var response = await _http.PutAsJsonAsync(
                $"api/customerappkeywordvalue/{dto.CXCAKVID}",
                command
            );

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteCustomerAppKeywordValueAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/customerappkeywordvalue/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
