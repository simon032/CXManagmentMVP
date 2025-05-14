using CXManagmentMVP.Domain.Entities;

namespace CXManagmentMVP.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(int id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetByEmailAsync(string email);
        Task<int> AddAsync(Customer customer);
        Task<bool> UpdateAsync(Customer customer);
        Task<bool> DeleteAsync(int id);

    }
}
