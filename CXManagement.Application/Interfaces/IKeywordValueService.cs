using CXManagement.Application.DTOs.KeywordValue;

namespace CXManagement.Application.Interfaces
{
    public interface IKeywordValueService
    {
        Task<KeywordValueDto> GetByIdAsync(int id);
        Task<List<KeywordValueDto>> GetByCustomerIdAsync(int customerId);
        Task<KeywordValueDto> AddAsync(AddKeywordValueDto addDto);
        Task<bool> DeleteAsync(int id);
    }
}
