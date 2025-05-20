using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using CXManagmentMVP.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CXManagmentMVP.Infrastructure.Repositories
{
    public class CustomerAppKeywordValueRepository : ICustomerAppKeywordValueRepository
    {
        private readonly CXManagementDbContext _context;

        public CustomerAppKeywordValueRepository(CXManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CX_Customer_AppKeyword_Value entity)
        {
            await _context.CustomerAppKeywordValues.AddAsync(entity);
        }

        public void Delete(CX_Customer_AppKeyword_Value entity)
        {
            _context.CustomerAppKeywordValues.Remove(entity);
        }

        public async Task<IEnumerable<CX_Customer_AppKeyword_Value>> GetAllAsync()
        {
            return await _context.CustomerAppKeywordValues.ToListAsync();
        }

        public async Task<CX_Customer_AppKeyword_Value> GetByIdAsync(int id)
        {
            return await _context.CustomerAppKeywordValues.FindAsync(id);
        }

        public void Update(CX_Customer_AppKeyword_Value entity)
        {
            _context.CustomerAppKeywordValues.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<CX_Customer_AppKeyword_Value>> GetCustomerAppKeywordValueViewByCustomerId(int id)
        {
            return await _context.CustomerAppKeywordValues.Include(c => c.ApplicationKeyword)
                    .ThenInclude(ak => ak.Application)
                    .Include(c => c.ApplicationKeyword)
                    .ThenInclude(ak => ak.Keyword)
                    .Where(c => c.CXCustomerID == id)
                    .ToListAsync();
        }
    }
}
