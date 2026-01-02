using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.OrderDetail
{
    public class CreateOrderDetailDto
    {
        public int OrderHeaderId { get; set; }
        public int ProductId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "En az 1 adet olmalýdýr.")]
        public int Count { get; set; }
        public double Price { get; set; } // Sipariþ anýndaki fiya
    }
}
