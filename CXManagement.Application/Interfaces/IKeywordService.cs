using CXManagement.Application.DTOs.Keyword;

namespace CXManagement.Application.Interfaces
{
    public interface IKeywordService
    {
        Task<KeywordDto> GetByIdAsync(int id);
        Task<List<KeywordDto>> GetAllAsync();
        Task<KeywordDto> CreateAsync(CreateKeywordDto createDto);
        Task<bool> UpdateAsync(int id, UpdateKeywordDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
