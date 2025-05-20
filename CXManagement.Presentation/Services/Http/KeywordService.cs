using CXManagement.Application.DTOs.CX_Application_Keyword;
using CXManagement.Application.DTOs.CX_Keyword;
using CXManagement.Application.UseCases.ApplicationKeyword;
using CXManagement.Application.UseCases.Keyword;
using System.Net.Http.Json;

namespace CXManagement.Presentation.Services.Http
{
    public class KeywordService
    {
        private readonly HttpClient _http;
        private int? SelectedApplicationId { get; set; }

        public KeywordService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<KeywordDto>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<IEnumerable<KeywordDto>>("api/keyword");
        }

        public async Task<KeywordDto> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<KeywordDto>($"api/keyword/{id}");
        }

        public async Task<int> CreateAsync(CreateKeywordDto model)
        {
            var createKeywordCommand = new CreateKeywordCommand
            {
                Keyword = model
            };

            var response = await _http.PostAsJsonAsync("api/keyword", createKeywordCommand);
            response.EnsureSuccessStatusCode();

            var keywordID = await response.Content.ReadFromJsonAsync<int>();

            return keywordID;
        }

        public async Task<bool> UpdateAsync(UpdateKeywordDto model)
        {
            var response = await _http.PutAsJsonAsync($"api/keyword/{model.CXKeywordID}", new { Keyword = model });
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/keyword/{id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> CreateApplicationKeywordAsync(CreateApplicationKeywordDto dto)
        {
            var command = new CreateApplicationKeywordCommand { ApplicationKeyword = dto };
            var response = await _http.PostAsJsonAsync("api/applicationkeyword", command);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteApplicationKeywordAsync(int keywordId, int applicationId)
        {
            var requestUri = $"api/applicationkeyword/{keywordId}/{applicationId}";

            var response = await _http.DeleteAsync(requestUri);
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<KeywordDto>> GetAllKeywordsByApplicationIdAsync(int appId)
        {
            return await _http.GetFromJsonAsync<IEnumerable<KeywordDto>>(
                $"api/keyword/GetAllKeywordsByApplicationId/{appId}"
            );
        }

    }
}
