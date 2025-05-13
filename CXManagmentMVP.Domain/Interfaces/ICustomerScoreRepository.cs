using CXManagmentMVP.Domain.Entities;

namespace CXManagmentMVP.Domain.Interfaces
{
    public interface ICustomerScoreRepository
    {
        Task<CustomerScore?> GetByCustomerIdAsync(int customerId);
        Task AddAsync(CustomerScore score);
        Task<bool> UpdateScoreAsync(CustomerScore score);
        Task<bool> DeleteScoreAsync(CustomerScore score);
    }
}
