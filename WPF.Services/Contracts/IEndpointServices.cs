using System.Reflection;

namespace WPF.Services.Contracts
{
    public interface IEndpointServices
    {
        Task SeedEndpointsAsync(Assembly webAssembly);
    }
}