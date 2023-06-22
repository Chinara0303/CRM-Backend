using Services.DTOs.Subscribe;

namespace Services.Services.İnterfaces
{
    public interface ISubscribeService
    {
        Task<IEnumerable<SubscribeDto>> GetAllAsync();
        Task<SubscribeDto> GetByIdAsync(int? id);
        Task CreateAsync(SubscribeCreateDto model);
        Task SoftDeleteAsync(int? id);
    }
}
