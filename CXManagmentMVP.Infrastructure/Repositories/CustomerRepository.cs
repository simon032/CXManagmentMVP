using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using CXManagmentMVP.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CXManagmentMVP.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CXManagementDbContext _context;

        public CustomerRepository(CXManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CX_Customer entity)
        {
            await _context.Customers.AddAsync(entity);
        }

        public void Delete(CX_Customer entity)
        {
            _context.Customers.Remove(entity);
        }

        public async Task<IEnumerable<CX_Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<CX_Customer> GetByEmailAsync(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.CXCustomerEmail == email);
        }

        public async Task<CX_Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.Include(c => c.Values).FirstOrDefaultAsync(c => c.CXCustomerID == id);
        }

        public void Update(CX_Customer entity)
        {
            _context.Customers.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
