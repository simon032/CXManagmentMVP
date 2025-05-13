using CXManagmentMVP.Domain.Entities;

namespace CXManagmentMVP.Domain.Interfaces
{
    public interface IApplicationSystemRepository
    {
        Task<ApplicationSystem?> GetByIdAsync(Guid id);
        Task<IEnumerable<ApplicationSystem>> GetAllAsync();
        Task AddAsync(ApplicationSystem appSystem);
        void Update(ApplicationSystem appSystem);
        void Remove(ApplicationSystem appSystem);
    }
}
