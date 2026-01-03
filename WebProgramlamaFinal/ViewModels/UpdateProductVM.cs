using Microsoft.AspNetCore.Mvc.Rendering;
using WPF.Models.Dtos.Category;
using WPF.Models.Dtos.Product;

namespace WPF.MVC.ViewModels
{
    public class UpdateProductVM
    {
        public UpdateProductDto Product { get; set; } = new UpdateProductDto();
        public IEnumerable<SelectListItem>? CategoryList { get; set; }
    }
}
