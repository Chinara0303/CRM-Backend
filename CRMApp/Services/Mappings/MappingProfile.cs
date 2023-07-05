using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Services.DTOs.About;
using Services.DTOs.Account;
using Services.DTOs.Banner;
using Services.DTOs.Contact;
using Services.DTOs.Education;
using Services.DTOs.Group;
using Services.DTOs.Room;
using Services.DTOs.Seans;
using Services.DTOs.Setting;
using Services.DTOs.SiteSocial;
using Services.DTOs.Slider;
using Services.DTOs.Student;
using Services.DTOs.Subscribe;
using Services.DTOs.Teacher;
using Services.DTOs.TeacherGroup;
using Services.DTOs.TecherSocial;
using Services.DTOs.Time;

namespace Services.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<SignUpDto, AppUser>();
            CreateMap<AppUser, UserListDto>();
            CreateMap<AppUser, UserDto>();
            CreateMap<AppUser, StatusDto>();
            CreateMap<UserUpdateDto, AppUser>();
            CreateMap<IdentityRole, RoleListDto>();
            CreateMap<IdentityRole, RoleDto>();

            CreateMap<Room, RoomDto>();
            CreateMap<RoomCreateDto,Room>();
            CreateMap<RoomUpdateDto,Room>();

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
            CreateMap<Group, GroupSearchDto>();
            CreateMap<GroupCreateDto, Group>();
            CreateMap<GroupUpdateDto, Group>();

            CreateMap<Time, TimeDto>();
            CreateMap<Time, TimeListDto>();
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


            CreateMap<TeacherGroup, TeacherGroupDto>();
            CreateMap<TeacherGroupCreateDto, TeacherGroup>();
            CreateMap<TeacherGroupUpdateDto, TeacherGroup>();


            CreateMap<Contact, ContactDto>();
            CreateMap<ContactCreateDto, Contact>();

            CreateMap<Subscribe, SubscribeDto>();
            CreateMap<SubscribeCreateDto, Subscribe>();

            CreateMap<Setting, SettingDto>();
            CreateMap<SettingUpdateDto, Setting>();
        }
    }
}
