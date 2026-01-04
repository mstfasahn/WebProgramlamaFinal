using Microsoft.AspNetCore.Mvc.Rendering;
using WPF.Models.Dtos.State;

namespace WPF.MVC.ViewModels.State
{
    public class UpdateStateVM
    {
        public UpdateStateDto State { get; set; } = new UpdateStateDto();
        public IEnumerable<SelectListItem> Cities { get; set; }  = new List<SelectListItem>();
    }
}
