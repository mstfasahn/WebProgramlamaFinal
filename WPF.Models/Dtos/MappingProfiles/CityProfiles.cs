using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models.Dtos.City;
using WPF.Models.Dtos.CityDtos;
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
            CreateMap<GetCityDto, UpdateCityDto>().ReverseMap();
            CreateMap<e.City, ListCityDto>()
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name));
        }
    }
}
