using System.ComponentModel.DataAnnotations;

namespace WPF.Models.Dtos.ShoppingCart
{
    // ShoppingCartDto.cs
    public class GetShoppingCartDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Count { get; set; }
        public int UserId { get; set; }
        public double Price { get; set; } // Unit Price
        public string ImageUrl { get; set; } //Product Image

        public double LinePrice => Count * Price;
    }
}
