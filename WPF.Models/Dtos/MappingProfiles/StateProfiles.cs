using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models.Dtos.State;
using WPF.Models.Dtos.StateDtos;
using WPF.Models.Dtos.User;
using e = WPF.Models.Entities;

namespace WPF.Models.Dtos.MappingProfiles
{
    public class StateProfiles:Profile
    {
        public StateProfiles()
        {
            CreateMap<e.State, CreateStateDto>().ReverseMap();
            CreateMap<e.State, GetStateDto>();
            CreateMap<e.State, UpdateStateDto>().ReverseMap();
            CreateMap<GetStateDto,UpdateStateDto>().ReverseMap();
            CreateMap<e.State, ListStateDto>()
                            .IncludeBase<e.State, GetStateDto>()
                            .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name));
        }
    }
}
