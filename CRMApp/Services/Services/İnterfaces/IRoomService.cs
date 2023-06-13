using Services.DTOs.Room;


namespace Services.Services.İnterfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetAllAsync();
        Task<RoomDto> GetByIdAsync(int? id);
        Task CreateAsync(RoomCreateDto model);
        Task UpdateAsync(int? id,RoomUpdateDto model);
        Task SoftDeleteAsync(int? id);
    }
}
