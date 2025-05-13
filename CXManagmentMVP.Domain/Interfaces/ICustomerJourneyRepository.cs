using CXManagmentMVP.Domain.Entities;

namespace CXManagmentMVP.Domain.Interfaces
{
    public interface ICustomerJourneyRepository
    {
        Task<IEnumerable<CustomerJourney>> GetByCustomerIdAsync(Guid customerId);
        Task AddAsync(CustomerJourney journey);
        void Update(CustomerJourney journey);
        void Remove(CustomerJourney journey);
    }

}
