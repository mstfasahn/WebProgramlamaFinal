using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WPF.Models.Dtos.Carrier;
using WPF.Models.Dtos.User;
using e = WPF.Models.Entities;

namespace WPF.Models.Dtos.MappingProfiles
{
    public class CarrierProfiles:Profile
    {
        public CarrierProfiles()
        {
            CreateMap<e.Carrier,CreateCarrierDto>().ReverseMap();
            CreateMap<e.Carrier, GetCarrierDto>();
            CreateMap<e.Carrier,UpdateCarrierDto>().ReverseMap();
            CreateMap<GetCarrierDto, UpdateCarrierDto>().ReverseMap();
        }
    }
}
