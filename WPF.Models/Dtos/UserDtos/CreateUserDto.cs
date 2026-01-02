using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.User
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Ad Soyad zorunludur.")]
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? StreetAddress { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CompanyId { get; set; }
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Þifre zorunludur.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Þifre en az 6 karakter olmalýdýr.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Þifreler uyuþmuyor.")]
        public string ConfirmPassword { get; set; }
    }
}
