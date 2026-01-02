using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? StreetAddress { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public string? PhoneNumber { get; set; }

        public City City { get; set; }
        public State State { get; set; }
    }
}
