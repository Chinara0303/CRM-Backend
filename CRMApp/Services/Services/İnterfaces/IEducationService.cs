using Services.DTOs.Education;

namespace Services.Services.İnterfaces
{
    public interface IEducationService
    {
        Task<IEnumerable<EducationListDto>> GetAllAsync();
        Task<EducationDto> GetByIdAsync(int? id);
        Task CreateAsync(EducationCreateDto model);
        Task UpdateAsync(int? id, EductaionUpdateDto model);
        Task SoftDeleteAsync(int? id);
    }
}
