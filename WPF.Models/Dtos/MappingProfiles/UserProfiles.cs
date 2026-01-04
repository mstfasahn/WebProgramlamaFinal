using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models.Dtos.User;
using WPF.Models.Dtos.UserDtos;
using e = WPF.Models.Entities;

namespace WPF.Models.Dtos.MappingProfiles
{
    public class UserProfiles:Profile
    {
        public UserProfiles()
        {
            CreateMap<e.User, CreateUserDto>().ReverseMap();
            CreateMap<e.User, UserProfileDto>()
                .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.State.City.CountryId))
                .ForMember(dest=>dest.CityId,opt=>opt.MapFrom(src=>src.CityId))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
                .ForMember(dest => dest.StateName, opt => opt.MapFrom(src => src.State.Name))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.State.City.Name))
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.State.City.Country.Name));
            CreateMap<e.User, GetUserDto>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
            CreateMap<e.User, UpdateUserDto>().ReverseMap();
            CreateMap<e.User,UserLoginDto>().ReverseMap();
            CreateMap<e.User,UserRegisterDto>().ReverseMap();
            CreateMap<GetUserDto,UpdateUserDto>().ReverseMap();

        }
    }
}
