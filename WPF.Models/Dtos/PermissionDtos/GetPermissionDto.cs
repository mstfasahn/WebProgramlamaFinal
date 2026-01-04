using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.PermissionDtos
{
    public class GetPermissionDto: Profile
    {
        public int RoleId { get; set; }
        public int EndpointId { get; set; }
        public bool IsActive { get; set; }
    }
}
