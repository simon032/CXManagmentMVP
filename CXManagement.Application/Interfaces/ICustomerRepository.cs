using CXManagmentMVP.Domain.Entities;

namespace CXManagement.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task<CX_Customer> GetByEmailAsync(string email);

        Task<CX_Customer> GetByIdAsync(int id);
        Task<IEnumerable<CX_Customer>> GetAllAsync();
        Task AddAsync(CX_Customer entity);
        void Update(CX_Customer entity);
        void Delete(CX_Customer entity);
        Task<bool> SaveChangesAsync();
    }
}
