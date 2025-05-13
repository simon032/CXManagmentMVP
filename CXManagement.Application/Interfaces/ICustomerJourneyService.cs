using CXManagement.Application.DTOs.CustomerJourney;

namespace CXManagement.Application.Interfaces
{
    public interface ICustomerJourneyService
    {
        Task<CustomerJourneyDto> GetByIdAsync(int id);
        Task<List<CustomerJourneyDto>> GetByCustomerIdAsync(int customerId);
        Task<int> AddAsync(CreateCustomerJourneyDto trackDto);
        Task<bool> UpdateAsync(int id, UpdateCustomerJourneyDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
