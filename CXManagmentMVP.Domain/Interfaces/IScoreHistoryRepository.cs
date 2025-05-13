using CXManagmentMVP.Domain.Entities;

namespace CXManagmentMVP.Domain.Interfaces
{
    public interface IScoreHistoryRepository
    {
        Task<IEnumerable<ScoreHistory>> GetByCustomerIdAsync(int customerId);
        Task AddAsync(ScoreHistory history);
        Task<IEnumerable<ScoreHistory>> GetAllAsync();
    }
}
