using AutoMapper;
using Domain.Entities;
using Services.DTOs.About;
using Services.DTOs.Account;
using Services.DTOs.Course;
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

            CreateMap<About, AboutDto>();
            CreateMap<About, AboutListDto>();
            CreateMap<AboutCreateDto, About>();
            CreateMap<AboutUpdateDto, About>();

            CreateMap<Course, CourseDto>();
            CreateMap<Course, CourseListDto>();
            CreateMap<CourseCreateDto, Course>();
            CreateMap<CourseUpdateDto, Course>();
        }
    }
}
