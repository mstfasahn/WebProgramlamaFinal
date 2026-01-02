using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models.Dtos.OrderDetail;
using WPF.Models.Dtos.User;
using e = WPF.Models.Entities;

namespace WPF.Models.Dtos.MappingProfiles
{
    public class OrderDetailProfiles:Profile
    {
        public OrderDetailProfiles()
        {
            CreateMap<e.OrderDetail, CreateOrderDetailDto>().ReverseMap();
            CreateMap<e.OrderDetail, GetOrderDetailDto>();
            CreateMap<e.OrderDetail, UpdateOrderDetailDto>().ReverseMap();
        }
    }
}
