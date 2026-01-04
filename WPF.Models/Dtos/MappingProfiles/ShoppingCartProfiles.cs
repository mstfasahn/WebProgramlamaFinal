using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models.Dtos.ShoppingCart;
using WPF.Models.Dtos.User;
using e = WPF.Models.Entities;

namespace WPF.Models.Dtos.MappingProfiles
{
    public class ShoppingCartProfiles:Profile
    {
        public ShoppingCartProfiles()
        {
            CreateMap<e.ShoppingCart, CreateShoppingCartDto>().ReverseMap();
            CreateMap<e.ShoppingCart, GetShoppingCartDto>()

                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Title))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src =>
                src.Product.ProductImages != null && src.Product.ProductImages.Any()
                ? src.Product.ProductImages.FirstOrDefault().ImageUrl
                : "/images/no-image.png"))

                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price));

            CreateMap<e.ShoppingCart, UpdateShoppingCartDto>().ReverseMap();
            CreateMap<GetShoppingCartDto, UpdateShoppingCartDto>().ReverseMap();


        }
    }
}
