using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models.Dtos.User;
using e = WPF.Models.Entities;

namespace WPF.Models.Dtos.MappingProfiles
{
    public class UserProfiles:Profile
    {
        public UserProfiles()
        {
            CreateMap<e.User, CreateUserDto>().ReverseMap();
            CreateMap<e.User, GetUserDto>();
            CreateMap<e.User, UpdateUserDto>().ReverseMap();
            CreateMap<e.User,UserLoginDto>().ReverseMap();
            CreateMap<e.User,UserRegisterDto>().ReverseMap();
        }
    }
}
