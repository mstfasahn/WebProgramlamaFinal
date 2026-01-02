using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.Carrier
{
    public class UpdateCarrierDto : CreateCarrierDto
    {
        public int Id { get; set; }
    }
}
