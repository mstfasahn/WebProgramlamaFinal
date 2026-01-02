using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.ShoppingCart
{
    public class CreateShoppingCartDto
    {
        public int ProductId { get; set; }
        [Range(1, 100, ErrorMessage = "Adet 1-100 arasý olmalýdýr.")]
        public int Count { get; set; }
        public int UserId { get; set; }
        public double Price { get; set; } // Anlýk hesaplama için
    }
}
