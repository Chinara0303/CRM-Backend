using Services.DTOs.Social;

namespace Services.Services.İnterfaces
{
    public interface IStaffSocialService
    {
        Task<IEnumerable<StaffSocialDto>> GetAllAsync();
        Task<StaffSocialDto> GetByIdAsync(int? id);
        Task CreateAsync(StaffSocialCreateDto model);
        Task UpdateAsync(int? id, StaffSocialUpdateDto model);
        Task SoftDeleteAsync(int? id);
    }
}
