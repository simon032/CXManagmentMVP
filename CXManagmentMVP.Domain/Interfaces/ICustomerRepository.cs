using CXManagmentMVP.Domain.Entities;

namespace CXManagmentMVP.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(Guid id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetByEmailAsync(string email);
        Task AddAsync(Customer customer);
        void Update(Customer customer);
        void Remove(Customer customer);
    }
}
