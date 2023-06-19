using Services.DTOs.Staff;

namespace Services.Services.İnterfaces
{
    public interface IStaffService
    {
        Task<IEnumerable<StaffListDto>> GetAllAsync();
        Task<StaffDto> GetByIdAsync(int? id);
        Task CreateAsync(StaffCreateDto model);
        Task UpdateAsync(int? id, StaffUpdateDto model);
        Task SoftDeleteAsync(int? id);
    }
}
