using AutoMapper;
using Domain.Entities;
using Services.DTOs.About;
using Services.DTOs.Account;
using Services.DTOs.Banner;
using Services.DTOs.Education;
using Services.DTOs.Group;
using Services.DTOs.Position;
using Services.DTOs.Room;
using Services.DTOs.Seans;
using Services.DTOs.SiteSocial;
using Services.DTOs.Slider;
using Services.DTOs.Social;
using Services.DTOs.Staff;
using Services.DTOs.Student;
using Services.DTOs.Teacher;
using Services.DTOs.TecherSocial;
using Services.DTOs.Time;

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

            CreateMap<Education, EducationDto>();
            CreateMap<Education, EducationListDto>();
            CreateMap<EducationCreateDto, Education>();
            CreateMap<EductaionUpdateDto, Education>();


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
            CreateMap<GroupCreateDto, Group>();
            CreateMap<GroupUpdateDto, Group>();

            CreateMap<Time, TimeDto>();
            CreateMap<TimeCreateDto, Time>();
            CreateMap<TimeUpdateDto, Time>();

            CreateMap<Seans, SeansDto>();
            CreateMap<SeansCreateDto, Seans>();
            CreateMap<SeansUpdateDto, Seans>();


            CreateMap<Student, StudentDto>();
            CreateMap<Student, StudentListDto>();
            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentUpdateDto, Student>();

            CreateMap<Teacher, TeacherDto>();
            CreateMap<Teacher, TeacherListDto>();
            CreateMap<TeacherCreateDto, Teacher>();
            CreateMap<TeacherUpdateDto, Teacher>();

            CreateMap<TeacherSocial, TeacherSocialDto>();
            CreateMap<TeacherSocialCreateDto, TeacherSocial>();
            CreateMap<TeacherSocialUpdateDto, TeacherSocial>();

            CreateMap<Staff, StaffDto>();
            CreateMap<Staff, StaffListDto>();
            CreateMap<StaffCreateDto, Staff>();
            CreateMap<StaffUpdateDto, Staff>();

            CreateMap<StaffSocial, StaffSocialDto>();
            CreateMap<StaffSocialCreateDto, StaffSocial>();
            CreateMap<StaffSocialUpdateDto, StaffSocial>();


            CreateMap<SiteSocial, SiteSocialDto>();
            CreateMap<SiteSocialCreateDto, SiteSocial>();
            CreateMap<SiteSocialUpdateDto, SiteSocial>();
        }
    }
}
