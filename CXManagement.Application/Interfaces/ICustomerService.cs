using CXManagement.Application.DTOs.Customer;

namespace CXManagement.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetByIdAsync(int id);
        Task<List<CustomerDto>> GetAllAsync();
        Task<int> AddAsync(CreateCustomerDto createDto);
        Task<bool> UpdateAsync(int id, UpdateCustomerDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
