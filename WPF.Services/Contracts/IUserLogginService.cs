namespace WPF.Services.Contracts
{
    public interface IUserLogginService
    {
        Task LogAsync(int? userId, string controller, string action, string ip);
    }
}