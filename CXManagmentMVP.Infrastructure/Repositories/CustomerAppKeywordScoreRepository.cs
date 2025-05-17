using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using CXManagmentMVP.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CXManagmentMVP.Infrastructure.Repositories
{
    public class CustomerAppKeywordScoreRepository : ICustomerAppKeywordScoreRepository
    {
        private readonly CXManagementDbContext _context;

        public CustomerAppKeywordScoreRepository(CXManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CX_Customer_AppKeyword_Score entity)
        {
            await _context.CustomerAppKeywordScores.AddAsync(entity);
        }

        public void Delete(CX_Customer_AppKeyword_Score entity)
        {
            _context.CustomerAppKeywordScores.Remove(entity);
        }

        public async Task<IEnumerable<CX_Customer_AppKeyword_Score>> GetAllAsync()
        {
            return await _context.CustomerAppKeywordScores.ToListAsync();
        }

        public async Task<CX_Customer_AppKeyword_Score> GetByIdAsync(int id)
        {
            return await _context.CustomerAppKeywordScores.FindAsync(id);
        }

        public void Update(CX_Customer_AppKeyword_Score entity)
        {
            _context.CustomerAppKeywordScores.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
