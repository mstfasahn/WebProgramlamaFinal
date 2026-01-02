using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models.Dtos.Product;
using WPF.Models.Dtos.User;
using e = WPF.Models.Entities;

namespace WPF.Models.Dtos.MappingProfiles
{
    public class ProductProfiles:Profile
    {
        public ProductProfiles()
        {
            CreateMap<e.Product, CreateProductDto>().ReverseMap();
            CreateMap<e.Product, GetProductDto>();
            CreateMap<e.Product, UpdateProductDto>().ReverseMap();
        }
    }
}
