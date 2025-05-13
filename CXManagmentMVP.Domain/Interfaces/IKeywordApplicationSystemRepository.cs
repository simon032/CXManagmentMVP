using CXManagmentMVP.Domain.Entities;

namespace CXManagmentMVP.Domain.Interfaces
{
    public interface IKeywordApplicationSystemRepository
    {
        Task<KeywordApplicationSystem?> GetByIdAsync(int id);
        Task<IEnumerable<KeywordApplicationSystem>> GetByApplicationSystemIdAsync(int cxasid);
        Task<IEnumerable<KeywordApplicationSystem>> GetByKeywordIdAsync(int keywordId);
        Task AddAsync(KeywordApplicationSystem entity);
        void Update(KeywordApplicationSystem entity);
        void Remove(KeywordApplicationSystem entity);
    }
}
