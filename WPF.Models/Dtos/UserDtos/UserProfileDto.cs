using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.UserDtos
{
    public class UserProfileDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? StreetAddress { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CompanyId { get; set; }
        public int RoleId { get; set; }
        public int? CountryId { get; set; }
        public string RoleName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
    }
}
