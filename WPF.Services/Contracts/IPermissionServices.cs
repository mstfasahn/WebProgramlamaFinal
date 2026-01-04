using WPF.Models.Dtos.EndpointDtos;
using WPF.Models.Dtos.PermissionDtos;
using WPF.Models.Dtos.Role;

namespace WPF.Services.Contracts
{
    public interface IPermissionServices
    {
        Task<(IEnumerable<GetEndpointDto> Endpoints, IEnumerable<GetRoleDto> Roles, IEnumerable<GetPermissionDto> Permissions)> GetPermissionDataAsync();
        Task<bool> UpdatePermissionAsync(int roleId, int endpointId, bool isActive);
    }
}