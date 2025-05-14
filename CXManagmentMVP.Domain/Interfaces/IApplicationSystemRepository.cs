using CXManagmentMVP.Domain.Entities;

namespace CXManagmentMVP.Domain.Interfaces
{
    public interface IApplicationSystemRepository
    {
        Task<ApplicationSystem?> GetByIdAsync(int id);
        Task<IEnumerable<ApplicationSystem>> GetAllAsync();
        Task<int> AddAsync(ApplicationSystem appSystem);
        Task<bool> UpdateAsync(ApplicationSystem appSystem);
        Task<bool> DeleteAsync(int id);

    }
}
