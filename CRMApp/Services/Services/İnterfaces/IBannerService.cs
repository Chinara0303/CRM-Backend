using Services.DTOs.About;
using Services.DTOs.Banner;

namespace Services.Services.İnterfaces
{
    public interface IBannerService
    {
        Task<IEnumerable<BannerListDto>> GetAllAsync();
        Task<BannerDto> GetByIdAsync(int? id);
        Task CreateAsync(BannerCreateDto model);
        Task UpdateAsync(int? id, BannerUpdateDto model);
        Task DeleteAsync(int? id);
    }
}
