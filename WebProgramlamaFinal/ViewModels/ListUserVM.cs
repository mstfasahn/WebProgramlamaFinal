using Microsoft.AspNetCore.Mvc.Rendering;
using WPF.Models.Dtos.UserDtos;
using WPF.Models.Entities;

namespace WPF.MVC.ViewModels
{
    public class ListUserVM
    {
        public IEnumerable<User> Users { get; set; } = new List<User>();
        public IEnumerable<SelectListItem> Roles { get; set; } = Enumerable.Empty<SelectListItem>();

        //Filtreleme bilgilerini tutmak için:
        public string? NameSearch { get; set; } 
        public string? EmailSearch { get; set; }
        public int? SelectedRoleId { get; set; }
    }
}
