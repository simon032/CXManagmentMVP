using CXManagmentMVP.Domain.Entities;

namespace CXManagement.Application.Interfaces
{
    public interface IKeywordRepository
    {

        Task<CX_Keyword> GetByIdAsync(int id);
        Task<IEnumerable<CX_Keyword>> GetAllAsync();
        Task AddAsync(CX_Keyword entity);
        void Update(CX_Keyword entity);
        void Delete(CX_Keyword entity);
        Task<bool> SaveChangesAsync();
    }
}
