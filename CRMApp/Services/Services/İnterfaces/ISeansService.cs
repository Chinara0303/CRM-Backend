using Services.DTOs.Seans;

namespace Services.Services.İnterfaces
{
    public interface ISeansService
    {
        Task<IEnumerable<SeansDto>> GetAllAsync();
        Task<SeansDto> GetByIdAsync(int? id);
        Task CreateAsync(SeansCreateDto model);
        Task UpdateAsync(int? id, SeansUpdateDto model);
        Task SoftDeleteAsync(int? id);
    }
}
