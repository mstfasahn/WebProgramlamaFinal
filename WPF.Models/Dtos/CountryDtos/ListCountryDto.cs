using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models.Dtos.City;

namespace WPF.Models.Dtos.CountryDtos
{
    public class ListCountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GetCityDto> Cities { get; set; } = new();
    }
}
