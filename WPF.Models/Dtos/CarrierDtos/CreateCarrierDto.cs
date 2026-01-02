using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.Carrier
{
    public class CreateCarrierDto
    {
        [Required(ErrorMessage = "Kargo firmasý adý zorunludur.")]
        public required string Name { get; set; }
    }
}
