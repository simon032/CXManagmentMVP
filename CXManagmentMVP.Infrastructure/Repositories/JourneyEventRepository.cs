using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using CXManagmentMVP.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CXManagmentMVP.Infrastructure.Repositories
{
    public class JourneyEventRepository : IJourneyEventRepository
    {
        private readonly CXManagementDbContext _context;

        public JourneyEventRepository(CXManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CX_JourneyEvent entity)
        {
            await _context.JourneyEvents.AddAsync(entity);
        }

        public void Delete(CX_JourneyEvent entity)
        {
            _context.JourneyEvents.Remove(entity);
        }

        public async Task<IEnumerable<CX_JourneyEvent>> GetAllAsync()
        {
            return await _context.JourneyEvents.ToListAsync();
        }

        public async Task<CX_JourneyEvent> GetByIdAsync(int id)
        {
            return await _context.JourneyEvents.FindAsync(id);
        }

        public void Update(CX_JourneyEvent entity)
        {
            _context.JourneyEvents.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
