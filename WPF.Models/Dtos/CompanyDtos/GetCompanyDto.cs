using System.ComponentModel.DataAnnotations;

namespace WPF.Models.Dtos.Company
{
    // CompanyDto.cs
    public class GetCompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? StreetAddress { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
