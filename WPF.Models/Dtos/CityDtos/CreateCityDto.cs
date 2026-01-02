using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.City
{
    public class CreateCityDto
    {
        [Required(ErrorMessage = "Þehir adý zorunludur.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Þehir Kodu zorunludur.")]
        public string? PostalCode { get; set; }
        public int CountryId { get; set; }

    }
}
