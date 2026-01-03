using Microsoft.AspNetCore.Mvc.Rendering;
using WPF.Models.Dtos.City;
using WPF.Models.Dtos.CityDtos;

namespace WPF.MVC.ViewModels.City
{
    public class ListCityVM
    {
        // Entity (City) yerine DTO (ListCityDto) kullanýyoruz
        public IEnumerable<ListCityDto> Cities { get; set; } = new List<ListCityDto>();

        public string? SearchName { get; set; } = string.Empty;
        public string? SearchPostalCode { get; set; } = string.Empty;
        public int? SelectedCountryId { get; set; }
        public IEnumerable<SelectListItem>? CountryList { get; set; }= new List<SelectListItem>();
    }
}
