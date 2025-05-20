using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using CXManagmentMVP.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CXManagmentMVP.Infrastructure.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly CXManagementDbContext _context;

        public ApplicationRepository(CXManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CX_Application entity)
        {
            await _context.Applications.AddAsync(entity);
        }

        public void Delete(CX_Application entity)
        {
            _context.Applications.Remove(entity);
        }

        public async Task<IEnumerable<CX_Application>> GetAllAsync()
        {
            return await _context.Applications.ToListAsync();
        }

        public async Task<CX_Application> GetByIdAsync(int id)
        {
            return await _context.Applications.FindAsync(id);
        }

        public void Update(CX_Application entity)
        {
            _context.Applications.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<CX_Application>> GetAllApplicationKeywords()
        {
            return await _context.Applications
            .Where(app => app.ApplicationKeywords.Any())
            .Include(app => app.ApplicationKeywords)
            .ToListAsync();
        }
    }
}
