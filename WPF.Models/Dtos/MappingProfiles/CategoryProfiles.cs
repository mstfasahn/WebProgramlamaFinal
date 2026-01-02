using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models.Dtos.Category;
using WPF.Models.Dtos.User;
using e = WPF.Models.Entities;

namespace WPF.Models.Dtos.MappingProfiles
{
    public class CategoryProfiles:Profile
    {
        public CategoryProfiles()
        {
            CreateMap<e.Category, CreateCategoryDto>().ReverseMap();
            CreateMap<e.Category, GetCategoryDto>();
            CreateMap<e.Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<GetCategoryDto, UpdateCategoryDto>().ReverseMap();
        }
    }
}
