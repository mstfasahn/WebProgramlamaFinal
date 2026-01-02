using System.ComponentModel.DataAnnotations;

namespace WPF.Models.Dtos.OrderHeader
{
    // OrderHeaderDto.cs
    public class GetOrderHeaderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderTotal { get; set; }
        public string? OrderStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetAddress { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; }
    }
}
