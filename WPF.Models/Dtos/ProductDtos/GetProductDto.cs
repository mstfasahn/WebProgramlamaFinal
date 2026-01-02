using System.ComponentModel.DataAnnotations;

namespace WPF.Models.Dtos.Product
{
    // ProductDto.cs
    public class GetProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public double ListPrice { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
    }
}
