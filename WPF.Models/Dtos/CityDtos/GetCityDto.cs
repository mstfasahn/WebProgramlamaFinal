using System.ComponentModel.DataAnnotations;

namespace WPF.Models.Dtos.City
{
    // CityDto.cs
    public class GetCityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? PostalCode { get; set; }
        public int CountryId { get; set; }
    }
}
