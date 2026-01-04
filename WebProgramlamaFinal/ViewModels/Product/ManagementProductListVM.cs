using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using WPF.Models.Dtos.Category;
using WPF.Models.Dtos.Product;
using WPF.Models.Entities;

namespace WPF.MVC.ViewModels.Product
{
    public class ManagementProductListVM
    {
        [ValidateNever]
        public IEnumerable<GetCategoryDto> Categories { get; set; } = new List<GetCategoryDto>();
        public IEnumerable<GetProductDto> Products { get; set; } =Enumerable.Empty<GetProductDto>();
    }
}
