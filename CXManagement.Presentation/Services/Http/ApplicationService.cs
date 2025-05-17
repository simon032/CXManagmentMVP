using CXManagement.Application.DTOs.CX_Application;
using CXManagement.Application.UseCases.Application;
using System.Net.Http.Json;

namespace CXManagement.Presentation.Services.Http
{
    public class ApplicationService
    {
        private readonly HttpClient _httpClient;

        public ApplicationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ApplicationDto>> GetAllApplicationsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ApplicationDto>>("api/application");
        }

        public async Task<ApplicationDto> GetApplicationByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ApplicationDto>($"api/application/{id}");
        }

        public async Task<int> CreateApplicationAsync(CreateApplicationDto dto)
        {
            var command = new CreateApplicationCommand
            {
                Application = dto
            };

            var response = await _httpClient.PostAsJsonAsync("api/application", command);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<bool> UpdateApplicationAsync(UpdateApplicationDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/application/{dto.CXAID}", new { Application = dto });
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteApplicationAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/application/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
