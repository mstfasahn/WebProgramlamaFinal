using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.User
{
    public class UserLoginDto
    {
        public string? Email { get; set; }

        [Required(ErrorMessage = "Þifre zorunludur.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Þifre en az 5 karakter olmalýdýr.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
