using CXManagmentMVP.Domain.Entities;

namespace CXManagement.Application.Interfaces
{
    public interface IJourneyEventRepository
    {
        Task<CX_JourneyEvent> GetByIdAsync(int id);
        Task<IEnumerable<CX_JourneyEvent>> GetAllAsync();
        Task AddAsync(CX_JourneyEvent entity);
        void Update(CX_JourneyEvent entity);
        void Delete(CX_JourneyEvent entity);
        Task<bool> SaveChangesAsync();
    }
}
