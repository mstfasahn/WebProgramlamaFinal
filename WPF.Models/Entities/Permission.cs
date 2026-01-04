using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Entities
{
    public class Permission
    {
        public int Id { get; set; }
        public int EndpointId { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; } = false;
        public Endpoint? Endpoint { get; set; }
        public Role? Role { get; set; }
    }
}
