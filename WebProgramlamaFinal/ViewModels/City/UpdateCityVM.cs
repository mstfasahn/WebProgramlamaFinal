using Microsoft.AspNetCore.Mvc.Rendering;
using WPF.Models.Dtos.City;

namespace WPF.MVC.ViewModels.City
{
    public class UpdateCityVM
    {
        public UpdateCityDto City { get; set; }= new UpdateCityDto();
        public IEnumerable<SelectListItem> Countries { get; set; }= Enumerable.Empty<SelectListItem>();
    }
}
