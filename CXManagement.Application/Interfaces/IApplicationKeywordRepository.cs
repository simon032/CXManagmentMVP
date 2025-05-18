using CXManagmentMVP.Domain.Entities;

namespace CXManagement.Application.Interfaces
{
    public interface IApplicationKeywordRepository
    {
        Task<CX_Application_Keyword> GetByIdAsync(int id);
        Task<IEnumerable<CX_Application_Keyword>> GetAllAsync();
        Task AddAsync(CX_Application_Keyword entity);
        void Update(CX_Application_Keyword entity);
        void Delete(CX_Application_Keyword entity);
        Task<bool> SaveChangesAsync();
        Task<CX_Application_Keyword> GetByKeywordIdApplicationIdAsync(int keywordId, int applicationId);

    }
}
