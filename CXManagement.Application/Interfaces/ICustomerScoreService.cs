using CXManagement.Application.DTOs.CustomerScore;

namespace CXManagement.Application.Interfaces
{
    public interface ICustomerScoreService
    {
        Task<CustomerScoreDto> GetByIdAsync(int id);
        Task<List<CustomerScoreDto>> GetByCustomerIdAsync(int customerId);
        Task<int> AddAsync(CreateCustomerScoreDto createDto);
        Task<bool> UpdateAsync(int id, UpdateCustomerScoreDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
