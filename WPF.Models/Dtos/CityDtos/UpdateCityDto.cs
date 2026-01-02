using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.City
{
    public class UpdateCityDto: CreateCityDto
    {
        public int Id { get; set; }
    }
}
