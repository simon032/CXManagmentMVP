using CXManagmentMVP.Domain.Entities;

namespace CXManagmentMVP.Domain.Interfaces
{
    public interface IApplicationSystemRepository
    {
        Task<ApplicationSystem?> GetByIdAsync(int id);
        Task<IEnumerable<ApplicationSystem>> GetAllAsync();
        Task AddAsync(ApplicationSystem appSystem);
        Task UpdateAsync(ApplicationSystem appSystem);
        Task DeleteAsync(int id);

    }
}
