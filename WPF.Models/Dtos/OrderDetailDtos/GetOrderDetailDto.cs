using System.ComponentModel.DataAnnotations;

namespace WPF.Models.Dtos.OrderDetail
{
    // OrderDetailDto.cs
    public class GetOrderDetailDto
    {
        public int Id { get; set; }
        public int OrderHeaderId { get; set; }
        public int ProductId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "En az 1 adet olmalýdýr.")]
        public int Count { get; set; }
        public double Price { get; set; } // Sipariþ anýndaki fiyat
    }
}
