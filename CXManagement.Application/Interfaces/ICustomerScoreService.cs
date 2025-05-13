using CXManagement.Application.DTOs.CustomerScore;

namespace CXManagement.Application.Interfaces
{
    public interface ICustomerScoreService
    {
        Task<CustomerScoreDto> GetByIdAsync(int id);
        Task<List<CustomerScoreDto>> GetByCustomerIdAsync(int customerId);
        Task<CustomerScoreDto> CalculateScoreAsync(CalculateCustomerScoreDto calculateDto);
        Task<bool> UpdateScoreAsync(int id, UpdateCustomerScoreDto updateDto);
        Task<bool> DeleteScoreAsync(int id);
    }
}
