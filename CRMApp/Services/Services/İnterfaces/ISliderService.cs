using Services.DTOs.Slider;

namespace Services.Services.İnterfaces
{
    public interface ISliderService
    {
        Task<IEnumerable<SliderListDto>> GetAllAsync();
        Task<SliderDto> GetByIdAsync(int? id);
        Task CreateAsync(SliderCreateDto model);
        Task UpdateAsync(int? id, SliderUpdateDto model);
        Task SoftDeleteAsync(int? id);
    }
}
