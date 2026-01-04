using WPF.Models.Dtos.EndpointDtos;
using WPF.Models.Dtos.PermissionDtos;
using WPF.Models.Dtos.Role;

namespace WPF.MVC.ViewModels.Permission
{
    public class ListPermissionVM
    {
        public IEnumerable<GetEndpointDto> Endpoints{ get; set; } = Enumerable.Empty<GetEndpointDto>();
        public IEnumerable<GetRoleDto> Roles { get; set; }= Enumerable.Empty<GetRoleDto>();
        public IEnumerable<GetPermissionDto> Permissions { get; set; }=Enumerable.Empty<GetPermissionDto>();
    }
}
