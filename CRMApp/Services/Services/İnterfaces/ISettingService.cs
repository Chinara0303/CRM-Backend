using Services.DTOs.Setting;

namespace Services.Services.İnterfaces
{
    public interface ISettingService
    {
        Dictionary<string, string> GetAllWithDict();
        Task<IEnumerable<SettingDto>> GetAllAsync();
        Task<SettingDto> GetByIdAsync(int? id);
        Task UpdateAsync(int? id, SettingUpdateDto model);
        Task DeleteAsync(int? id);
    }
}
