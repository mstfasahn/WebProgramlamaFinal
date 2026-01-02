using System.ComponentModel.DataAnnotations;

namespace WPF.Models.Dtos.ShoppingCart
{
    // ShoppingCartDto.cs
    public class GetShoppingCartDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int UserId { get; set; }
        public double Price { get; set; } // Anlýk hesaplama için
    }
}
