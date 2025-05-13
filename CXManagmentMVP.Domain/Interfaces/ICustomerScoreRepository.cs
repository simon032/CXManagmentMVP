using CXManagmentMVP.Domain.Entities;

namespace CXManagmentMVP.Domain.Interfaces
{
    public interface ICustomerScoreRepository
    {
        Task<CustomerScore?> GetByCustomerIdAsync(Guid customerId);
        Task AddAsync(CustomerScore score);
        void Update(CustomerScore score);
    }
}
