using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models.Dtos.City;
using WPF.Models.Dtos.State;

namespace WPF.Models.Dtos.CityDtos
{
    public class ListCityDto
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string? PostalCode { get; set; }
            public string CountryName { get; set; }
            public List<GetStateDto> States { get; set; } = new();


    }

}
