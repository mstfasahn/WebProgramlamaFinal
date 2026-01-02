using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.Country
{
    public class CreateCountryDto
    {
        [Required(ErrorMessage = "Ülke adý zorunludur.")]
        public string Name { get; set; }
    }
}
