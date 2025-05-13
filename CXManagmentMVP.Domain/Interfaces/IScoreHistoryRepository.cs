using CXManagmentMVP.Domain.Entities;

namespace CXManagmentMVP.Domain.Interfaces
{
    public interface IScoreHistoryRepository
    {
        Task<IEnumerable<ScoreHistory>> GetByCustomerIdAsync(Guid customerId);
        Task AddAsync(ScoreHistory history);
        Task<IEnumerable<ScoreHistory>> GetAllAsync();
    }
}
