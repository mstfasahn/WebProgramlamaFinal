using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models.Dtos.EndpointDtos;
using WPF.Models.Entities;

namespace WPF.Models.Dtos.MappingProfiles
{
    public class EndpointProfiles:Profile
    {
        public EndpointProfiles()
        {
            CreateMap<Endpoint,GetEndpointDto>().ReverseMap();
            CreateMap<Endpoint,ListEndpointDto>().ReverseMap();
        }
    }
}
