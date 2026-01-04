using WPF.Models.Dtos.Role;
using WPF.Models.Entities;

namespace WPF.Services.Contracts
{
    public interface IRoleService
    {
        Task<IEnumerable<GetRoleDto>> GetRolesAsync();
    }
}