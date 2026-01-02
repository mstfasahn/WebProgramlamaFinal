using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models.Dtos.ProductImage;
using WPF.Models.Dtos.User;
using e = WPF.Models.Entities;

namespace WPF.Models.Dtos.MappingProfiles
{
    public class ProductImageProfiles:Profile
    {
        public ProductImageProfiles()
        {
            CreateMap<e.ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<e.ProductImage, GetProductImageDto>();
            CreateMap<e.ProductImage, UpdateProductImageDto>().ReverseMap();
        }
    }
}
