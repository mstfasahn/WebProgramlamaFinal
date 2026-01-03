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
            CreateMap<e.Product, GetProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src =>
                src.ProductImages != null && src.ProductImages.Any()
                ? src.ProductImages.FirstOrDefault().ImageUrl
                : "/images/no-image.png"))
                .ReverseMap();
            CreateMap<e.Product, UpdateProductDto>().ReverseMap();
        }
    }
}
