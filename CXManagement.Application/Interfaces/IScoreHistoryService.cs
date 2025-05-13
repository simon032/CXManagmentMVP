using CXManagement.Application.DTOs.ScoreHistory;

namespace CXManagement.Application.Interfaces
{
    public interface IScoreHistoryService
    {
        Task<ScoreHistoryDto> GetByIdAsync(int id);
        Task<List<ScoreHistoryDto>> GetByCustomerIdAsync(int customerId);
        Task<ScoreHistoryDto> LogAsync(LogScoreHistoryDto logDto);
        Task<bool> DeleteAsync(int id);
    }
}
