using CXManagmentMVP.Domain.Entities;

namespace CXManagement.Application.Interfaces
{
    public interface ICustomerAppKeywordValueRepository
    {
        Task<CX_Customer_AppKeyword_Value> GetByIdAsync(int id);
        Task<IEnumerable<CX_Customer_AppKeyword_Value>> GetAllAsync();
        Task AddAsync(CX_Customer_AppKeyword_Value entity);
        void Update(CX_Customer_AppKeyword_Value entity);
        void Delete(CX_Customer_AppKeyword_Value entity);
        Task<bool> SaveChangesAsync();

        Task<IEnumerable<CX_Customer_AppKeyword_Value>> GetCustomerAppKeywordValueViewByCustomerId(int id);
    }
}
