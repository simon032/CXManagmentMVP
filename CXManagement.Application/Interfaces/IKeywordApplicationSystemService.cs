using CXManagement.Application.DTOs.KeywordApplicationSystem;

namespace CXManagement.Application.Interfaces
{
    public interface IKeywordApplicationSystemService
    {
        Task<KeywordApplicationSystemDto> GetByIdAsync(int id);
        Task<List<KeywordApplicationSystemDto>> GetByApplicationSystemIdAsync(int applicationSystemId);
        Task<KeywordApplicationSystemDto> LinkKeywordToApplicationSystemAsync(LinkKeywordApplicationSystemDto linkDto);
        Task<bool> UpdateAsync(int id, UpdateKeywordApplicationSystemDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
