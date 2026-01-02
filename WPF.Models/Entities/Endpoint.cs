using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Entities
{
    public class Endpoint
    {
        public int Id { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

    }
}
