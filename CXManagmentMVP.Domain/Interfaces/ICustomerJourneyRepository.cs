using CXManagmentMVP.Domain.Entities;

namespace CXManagmentMVP.Domain.Interfaces
{
    public interface ICustomerJourneyRepository
    {
        Task<CustomerJourney> GetByIdAsync(int id);
        Task<IEnumerable<CustomerJourney>> GetByCustomerIdAsync(int customerId);
        Task<int> AddAsync(CustomerJourney journey);
        Task<bool> UpdateAsync(CustomerJourney journey);
        Task<bool> DeleteAsync(int id);
    }

}
