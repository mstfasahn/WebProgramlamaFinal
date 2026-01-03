using Microsoft.AspNetCore.Mvc.Rendering;
using WPF.Models.Dtos.City;
using WPF.Models.Dtos.Country;
using WPF.Models.Dtos.CountryDtos;

namespace WPF.MVC.ViewModels
{
    public class ListCountryVM
    {
        public IEnumerable<ListCountryDto> Countries { get; set; } = new List<ListCountryDto>();
        public string? SearchString { get; set; } = string.Empty;
    }
}
