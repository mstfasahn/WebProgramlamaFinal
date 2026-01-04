using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models.Dtos.PermissionDtos;
using WPF.Models.Dtos.State;

namespace WPF.Models.Dtos.EndpointDtos
{
    public class ListEndpointDto:GetEndpointDto
    {
        public List<GetPermissionDto> PermissionDtos { get; set; } = new();
    }
}
