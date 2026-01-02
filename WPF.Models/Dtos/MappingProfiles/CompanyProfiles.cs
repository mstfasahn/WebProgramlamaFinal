using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models.Dtos.Company;
using WPF.Models.Dtos.User;
using e = WPF.Models.Entities;

namespace WPF.Models.Dtos.MappingProfiles
{
    public class CompanyProfiles:Profile
    {
        public CompanyProfiles()
        {
            CreateMap<e.Company, CreateCompanyDto>().ReverseMap();
            CreateMap<e.Company, GetCompanyDto>();
            CreateMap<e.Company, UpdateCompanyDto>().ReverseMap();
        }
    }
}
