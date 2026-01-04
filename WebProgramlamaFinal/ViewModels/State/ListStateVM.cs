using Microsoft.AspNetCore.Mvc.Rendering;
using WPF.Models.Dtos.City;
using WPF.Models.Dtos.State;
using WPF.Models.Dtos.StateDtos;
using WPF.Models.Entities;

namespace WPF.MVC.ViewModels.State
{
    public class ListStateVM
    {
        public IEnumerable<SelectListItem>? Cities { get; set; }=new List<SelectListItem>();
        public IEnumerable<ListStateDto> States { get; set; } =new List<ListStateDto>();

        public string? SearchStateName { get; set; } = string.Empty;
        public int? SelectedCityId { get; set; }

    }
}
