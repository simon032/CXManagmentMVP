using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using CXManagmentMVP.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CXManagmentMVP.Infrastructure.Repositories
{
    public class KeywordRepository : IKeywordRepository
    {
        private readonly CXManagementDbContext _context;

        public KeywordRepository(CXManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CX_Keyword entity)
        {
            await _context.Keywords.AddAsync(entity);
        }

        public void Delete(CX_Keyword entity)
        {
            _context.Keywords.Remove(entity);
        }

        public async Task<IEnumerable<CX_Keyword>> GetAllAsync()
        {
            return await _context.Keywords
                    .Include(k => k.ApplicationKeywords)
                     .ThenInclude(ak => ak.Application)
                    .ToListAsync();
        }

        public async Task<CX_Keyword> GetByIdAsync(int id)
        {
            var result = await _context.Keywords.Include(k => k.ApplicationKeywords).FirstOrDefaultAsync(k => k.CXKeywordID == id);

            return result;
        }

        public void Update(CX_Keyword entity)
        {
            _context.Keywords.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<CX_Keyword>> GetAllKeywordsByApplicationId(int appId)
        {
            return await _context.Keywords
            .Where(k => k.ApplicationKeywords != null &&
                        k.ApplicationKeywords.Any(ak => ak.Application != null && ak.Application.CXAID == appId))
            .ToListAsync();
        }

        public async Task<IEnumerable<CX_Keyword>> GetCustomerAppKeywordValueViewByCustomerId(int customerId)
        {
            return await _context.Keywords
            .Where(k => k.ApplicationKeywords != null &&
                        k.ApplicationKeywords.Any(ak => ak.Application != null && ak.Application.CXAID == customerId))
            .ToListAsync();
        }
    }
}
