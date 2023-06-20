using Services.DTOs.SiteSocial;

namespace Services.Services.İnterfaces
{
    public interface ISiteSocialService
    {
        Task<IEnumerable<SiteSocialDto>> GetAllAsync();
        Task<SiteSocialDto> GetByIdAsync(int? id);
        Task CreateAsync(SiteSocialCreateDto model);
        Task UpdateAsync(int? id, SiteSocialUpdateDto model);
        Task SoftDeleteAsync(int? id);
    }
}
