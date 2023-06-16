using AutoMapper;
using Domain.Entities;
using Services.DTOs.About;
using Services.DTOs.Account;
using Services.DTOs.Banner;
using Services.DTOs.Course;
using Services.DTOs.Group;
using Services.DTOs.Position;
using Services.DTOs.Room;
using Services.DTOs.Slider;

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


            CreateMap<Slider, SliderDto>();
            CreateMap<Slider, SliderListDto>();
            CreateMap<SliderCreateDto, Slider>();
            CreateMap<SliderUpdateDto, Slider>();


            CreateMap<Banner, BannerDto>();
            CreateMap<Banner, BannerListDto>();
            CreateMap<BannerCreateDto, Banner>();
            CreateMap<BannerUpdateDto, Banner>();

            CreateMap<Group, GroupDto>();
            CreateMap<Group, GroupListDto>();
            CreateMap<GroupDto, GroupListDto>();
            CreateMap<GroupUpdateDto, Group>();

        }
    }
}
