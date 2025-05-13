using CXManagement.Application.DTOs.ApplicationSystem;

namespace CXManagement.Application.Interfaces
{
    public interface IApplicationSystemService
    {
        Task<ApplicationSystemDto> GetByIdAsync(int id);
        Task<List<ApplicationSystemDto>> GetAllAsync();
        Task<int> AddAsync(CreateApplicationSystemDto createDto);
        Task<bool> UpdateAsync(int id, UpdateApplicationSystemDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
