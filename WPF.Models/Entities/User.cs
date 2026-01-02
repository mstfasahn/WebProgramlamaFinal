using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPF.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string PasswordHash { get; set; }
        public string? StreetAddress { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CompanyId { get; set; }



        public Role? Role { get; set; }
        public Company? Company { get; set; }
        public City? City { get; set; }
        public State? State { get; set; }


    }
}
