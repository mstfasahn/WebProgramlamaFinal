using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.Country
{
    public class UpdateCountryDto: CreateCountryDto
    {
        public int Id { get; set; }
    }
}
