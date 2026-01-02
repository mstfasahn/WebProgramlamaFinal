using System.ComponentModel.DataAnnotations;

namespace WPF.Models.Dtos.ProductImage
{
    // ProductImageDto.cs
    public class GetProductImageDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }
    }
}
