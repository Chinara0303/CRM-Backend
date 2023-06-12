using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.İnterfaces;
using Services.DTOs.Room;
using Services.Services.İnterfaces;


namespace Services.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repo;
        public RoomService(IRoomRepository repo,AppDbContext context)
        {
            _repo = repo;
        }
        public Task<bool> CheckByNameAsync(RoomDto model)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(RoomCreateDto model)
        {
            if (model is null) throw new ArgumentNullException("Data not found");
            var room = new Room()
            {
                Name = model.Name,
            };
            await _repo.CreateAsync(room);
        }

        public Task<IEnumerable<RoomDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RoomDto> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int? id, RoomUpdateDto model)
        {
            throw new NotImplementedException();
        }
    }
}
