using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Entities
{
    public class UserLog
    {
        public int Id { get; set; }
        public int? UserId { get; set; } // Giriþ yapmamýþsa null olabilir
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string IpAddress { get; set; }
        public DateTime LogDate { get; set; } = DateTime.Now;
    }
}
