using CXManagmentMVP.Domain.Entities;

namespace CXManagement.Application.Interfaces
{
    public interface ICustomerRepository : IRepository<CX_Customer>
    {
        Task<CX_Customer> GetByEmailAsync(string email);
    }
}
