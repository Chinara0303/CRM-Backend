using AutoMapper;
using Domain.Entities;
using Services.DTOs.Account;
using Services.DTOs.Position;
using Services.DTOs.Room;

namespace Services.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<SignUpDto, AppUser>();

            CreateMap<Room, RoomDto>();
            CreateMap<RoomCreateDto,Room>();
            CreateMap<RoomUpdateDto,Room>();

            CreateMap<Position, PositionDto>();
            CreateMap<PositionCreateDto, Position>();
            CreateMap<PositionUpdateDto, Position>();
        }
    }
}
