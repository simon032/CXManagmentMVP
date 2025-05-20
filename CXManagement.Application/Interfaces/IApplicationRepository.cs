using CXManagmentMVP.Domain.Entities;

namespace CXManagement.Application.Interfaces
{
    public interface IApplicationRepository
    {
        Task<CX_Application> GetByIdAsync(int id);
        Task<IEnumerable<CX_Application>> GetAllAsync();
        Task AddAsync(CX_Application entity);
        void Update(CX_Application entity);
        void Delete(CX_Application entity);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<CX_Application>> GetAllApplicationKeywords();
    }
}
