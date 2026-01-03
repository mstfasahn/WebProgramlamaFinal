using WPF.Models.Dtos.User;
using WPF.Models.Dtos.UserDtos;
using WPF.Models.Entities;

namespace WPF.Services.Contracts
{
    public interface IUserService
    {
        Task<bool> DeleteUser(int id, int currentSessionUserId);
        Task<IEnumerable<User>> GetAllUserWithRoles();
        Task<GetUserDto> GetUserByIdAsync(int id);
        Task<UserProfileDto> GetUserByIdForProfileAsync(int id);
        Task<bool> IsAValidRequest(int userId, int roleId);
        Task<GetUserDto> UpdateUserAsync(UpdateUserDto dto, int currentSessionUserId);
    }
}