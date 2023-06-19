using Services.DTOs.Social;

namespace Services.Services.İnterfaces
{
    public interface ISocialService
    {
        Task<IEnumerable<SocialDto>> GetAllAsync();
        Task<SocialDto> GetByIdAsync(int? id);
        Task CreateAsync(SocialCreateDto model);
        Task UpdateAsync(int? id, SocialUpdateDto model);
        Task SoftDeleteAsync(int? id);
    }
}
