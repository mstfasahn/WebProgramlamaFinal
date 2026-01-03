using WPF.Models.Dtos.Category;
using WPF.Models.Dtos.Product;
using WPF.Models.Entities;

namespace WPF.MVC.ViewModels.Product
{
    public class CreateProductVM
    {
        public IEnumerable<GetCategoryDto> Categories { get; set; } = new List<GetCategoryDto>();
        public CreateProductDto CreateProductDto { get; set; } = new CreateProductDto();
        public ProductImage ProductImage { get; set; } = new ProductImage();
    }
}
