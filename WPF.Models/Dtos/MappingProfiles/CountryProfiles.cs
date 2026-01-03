using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models.Dtos.Country;
using WPF.Models.Dtos.CountryDtos;
using WPF.Models.Dtos.User;
using e = WPF.Models.Entities;

namespace WPF.Models.Dtos.MappingProfiles
{
    public class CountryProfiles:Profile
    {
        public CountryProfiles()
        {
            CreateMap<e.Country, CreateCountryDto>().ReverseMap();
            CreateMap<e.Country, GetCountryDto>();
            CreateMap<e.Country, UpdateCountryDto>().ReverseMap();
            CreateMap<e.Country,ListCountryDto>().ReverseMap();
            CreateMap<GetCountryDto, UpdateCountryDto>().ReverseMap();
        }
    }
}
