using Microsoft.AspNetCore.Mvc.Rendering;
using WPF.Models.Dtos.City;

namespace WPF.MVC.ViewModels.City
{
    public class CreateCityVM
    {
        public CreateCityDto City { get; set; } = new CreateCityDto();
        public IEnumerable<SelectListItem> CountryList { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
