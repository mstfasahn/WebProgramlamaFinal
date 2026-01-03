using WPF.Models.Entities;

namespace WPF.Services.Contracts
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetRoles();
    }
}