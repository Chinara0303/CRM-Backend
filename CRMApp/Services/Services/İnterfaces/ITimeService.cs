using Services.DTOs.Time;

namespace Services.Services.İnterfaces
{
    public interface ITimeService
    {
        Task<IEnumerable<TimeListDto>> GetAllAsync();
        Task<TimeDto> GetByIdAsync(int? id);
        Task CreateAsync(TimeCreateDto model);
        Task UpdateAsync(int? id, TimeUpdateDto model);
        Task SoftDeleteAsync(int? id);
    }
}
