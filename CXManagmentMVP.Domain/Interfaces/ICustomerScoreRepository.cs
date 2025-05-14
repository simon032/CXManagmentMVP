using CXManagmentMVP.Domain.Entities;

namespace CXManagmentMVP.Domain.Interfaces
{
    public interface ICustomerScoreRepository
    {
        Task<CustomerScore?> GetByIdAsync(int id);
        Task<List<CustomerScore?>> GetByCustomerIdAsync(int customerId);
        Task AddAsync(CustomerScore score);
        Task<bool> UpdateAsync(CustomerScore score);
        Task<bool> DeleteAsync(int id);
    }
}
