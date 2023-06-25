using Services.DTOs.About;

namespace Services.Services.İnterfaces
{
    public interface IAboutService
    {
        Task<IEnumerable<AboutListDto>> GetAllAsync();
        Task<AboutDto> GetByIdAsync(int? id);
        Task CreateAsync(AboutCreateDto model);
        Task UpdateAsync(int? id, AboutUpdateDto model);
        Task DeleteAsync(int? id);
    }
}
