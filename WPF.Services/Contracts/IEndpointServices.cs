using System.Reflection;
using WPF.Models.Dtos.EndpointDtos;

namespace WPF.Services.Contracts
{
    public interface IEndpointServices
    {
        Task<IEnumerable<GetEndpointDto>> GetEndpointsAsync();
        Task<IEnumerable<ListEndpointDto>> GetEndpointsWIncludesAsync();
        Task SeedEndpointsAsync(Assembly webAssembly);
    }
}