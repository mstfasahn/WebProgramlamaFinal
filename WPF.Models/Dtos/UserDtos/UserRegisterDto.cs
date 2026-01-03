using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.User
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "Ad Soyad zorunludur.")]
        public string Name { get; set; }
        public string? Email { get; set; }

        [Required(ErrorMessage = "Þifre zorunludur.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Þifre en az 6 karakter olmalýdýr.")]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        [Compare("PasswordHash", ErrorMessage = "Þifreler uyuþmuyor.")]
        public string ConfirmPassword { get; set; }
    }
}
