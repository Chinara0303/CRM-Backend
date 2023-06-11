using AutoMapper;
using Domain.Entities;
using Services.DTOs.Account;

namespace Services.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<SignUpDto, AppUser>();
        }
    }
}
