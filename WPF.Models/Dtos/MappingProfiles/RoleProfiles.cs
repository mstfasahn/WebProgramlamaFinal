using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models.Dtos.Role;
using WPF.Models.Dtos.User;
using e = WPF.Models.Entities;

namespace WPF.Models.Dtos.MappingProfiles
{
    public class RoleProfiles:Profile
    {
        public RoleProfiles()
        {
            CreateMap<e.Role, CreateRoleDto>().ReverseMap();
            CreateMap<e.Role, GetRoleDto>();
            CreateMap<e.Role, UpdateRoleDto>().ReverseMap();
        }
    }
}
