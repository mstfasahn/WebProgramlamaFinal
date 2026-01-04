using Microsoft.AspNetCore.Mvc.Rendering;
using WPF.Models.Dtos.City;
using WPF.Models.Dtos.State;

namespace WPF.MVC.ViewModels.State
{
    public class CreateStateVM
    {
        public CreateStateDto State { get; set; }=new CreateStateDto();
        public IEnumerable<SelectListItem> Cities { get; set; } = new List<SelectListItem>();

    }
}
