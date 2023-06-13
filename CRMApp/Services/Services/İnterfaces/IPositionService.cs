using Services.DTOs.Position;

namespace Services.Services.İnterfaces
{
    public interface IPositionService
    {
        Task<IEnumerable<PositionDto>> GetAllAsync();
        Task<PositionDto> GetByIdAsync(int? id);
        Task CreateAsync(PositionCreateDto model);
        Task UpdateAsync(int? id, PositionUpdateDto model);
        Task SoftDeleteAsync(int? id);
    }
}
