using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using CXManagmentMVP.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CXManagmentMVP.Infrastructure.Repositories
{
    public class ApplicationKeywordRepository : IApplicationKeywordRepository
    {
        private readonly CXManagementDbContext _context;

        public ApplicationKeywordRepository(CXManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CX_Application_Keyword entity)
        {
            await _context.ApplicationKeywords.AddAsync(entity);
        }

        public void Delete(CX_Application_Keyword entity)
        {
            _context.ApplicationKeywords.Remove(entity);
        }

        public async Task<IEnumerable<CX_Application_Keyword>> GetAllAsync()
        {
            return await _context.ApplicationKeywords.ToListAsync();
        }

        public async Task<CX_Application_Keyword> GetByIdAsync(int id)
        {
            return await _context.ApplicationKeywords.FindAsync(id);
        }

        public void Update(CX_Application_Keyword entity)
        {
            _context.ApplicationKeywords.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
