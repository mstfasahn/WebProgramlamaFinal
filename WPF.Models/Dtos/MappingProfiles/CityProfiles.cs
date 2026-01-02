using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models.Dtos.City;
using WPF.Models.Dtos.User;
using e = WPF.Models.Entities;

namespace WPF.Models.Dtos.MappingProfiles
{
    public class CityProfiles:Profile
    {
        public CityProfiles()
        {
            CreateMap<e.City, CreateCityDto>().ReverseMap();
            CreateMap<e.City, GetCityDto>();
            CreateMap<e.City, UpdateCityDto>().ReverseMap();
        }
    }
}
