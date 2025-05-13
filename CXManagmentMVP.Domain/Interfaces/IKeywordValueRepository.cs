using CXManagmentMVP.Domain.Entities;

namespace CXManagmentMVP.Domain.Interfaces
{
    public interface IKeywordValueRepository
    {
        Task<IEnumerable<KeywordValue>> GetByCustomerIdAsync(Guid customerId);
        Task AddAsync(KeywordValue value);
        void Update(KeywordValue value);
        void Remove(KeywordValue value);
    }
}
