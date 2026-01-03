using WPF.Models.Dtos.User;

namespace WPF.Services.Contracts
{
    public interface IAuthService
    {
        Task<GetUserDto?> LoginAsync(UserLoginDto loginDto);
        Task LogoutAsync();
        Task RegisterAsync(UserRegisterDto registerDto);
    }
}