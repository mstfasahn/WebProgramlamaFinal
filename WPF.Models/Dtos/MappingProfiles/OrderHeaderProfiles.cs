using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models.Dtos.OrderHeader;
using WPF.Models.Dtos.User;
using e = WPF.Models.Entities;

namespace WPF.Models.Dtos.MappingProfiles
{
    public class OrderHeaderProfiles:Profile
    {
        public OrderHeaderProfiles()
        {
            CreateMap<e.OrderHeader, CreateOrderHeaderDto>().ReverseMap();
            CreateMap<e.OrderHeader, GetOrderHeaderDto>();
            CreateMap<e.OrderHeader, UpdateOrderHeaderDto>().ReverseMap();
        }
    }
}
