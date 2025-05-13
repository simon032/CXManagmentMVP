using CXManagmentMVP.Domain.Entities;

namespace CXManagmentMVP.Domain.Interfaces
{
    public interface IKeywordRepository
    {
        Task<Keyword?> GetByIdAsync(Guid id);
        Task<IEnumerable<Keyword>> GetAllAsync();
        Task AddAsync(Keyword keyword);
        void Update(Keyword keyword);
        void Remove(Keyword keyword);
    }
}
