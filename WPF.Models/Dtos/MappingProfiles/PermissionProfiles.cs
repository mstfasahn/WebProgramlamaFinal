using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models.Dtos.PermissionDtos;
using WPF.Models.Entities;

namespace WPF.Models.Dtos.MappingProfiles
{
    public class PermissionProfiles: Profile
    {
        public PermissionProfiles()
        {
            CreateMap<Permission, GetPermissionDto>().ReverseMap();

        }
    }
}
