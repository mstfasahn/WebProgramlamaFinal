using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Entities
{
    public class Carrier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  ICollection<OrderHeader> Orders { get; set; }
    }
}
