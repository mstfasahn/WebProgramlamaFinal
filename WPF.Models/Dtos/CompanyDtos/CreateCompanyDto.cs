using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.Company
{
    public class CreateCompanyDto
    {
        [Required(ErrorMessage = "Þirket adý zorunludur.")]
        public string Name { get; set; }
        public string? StreetAddress { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        [Phone(ErrorMessage = "Geçersiz telefon formatý.")]
        public string? PhoneNumber { get; set; }
    }
}
