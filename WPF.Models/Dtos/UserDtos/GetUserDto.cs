using System.ComponentModel.DataAnnotations;

namespace WPF.Models.Dtos.User
{
    // UserDto.cs
    public class GetUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? StreetAddress { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CompanyId { get; set; }
        public int RoleId { get; set; }
    }
}
