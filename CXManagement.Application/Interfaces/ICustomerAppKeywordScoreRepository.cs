using CXManagmentMVP.Domain.Entities;

namespace CXManagement.Application.Interfaces
{
    public interface ICustomerAppKeywordScoreRepository
    {
        Task<CX_Customer_AppKeyword_Score> GetByIdAsync(int id);
        Task<IEnumerable<CX_Customer_AppKeyword_Score>> GetAllAsync();
        Task AddAsync(CX_Customer_AppKeyword_Score entity);
        void Update(CX_Customer_AppKeyword_Score entity);
        void Delete(CX_Customer_AppKeyword_Score entity);
        Task<bool> SaveChangesAsync();
    }
}
