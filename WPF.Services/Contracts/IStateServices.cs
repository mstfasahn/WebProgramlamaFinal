using WPF.Models.Dtos.State;
using WPF.Models.Dtos.StateDtos;

namespace WPF.Services.Contracts
{
    public interface IStateServices
    {
        Task<GetStateDto> CreateStateAsync(CreateStateDto dto);
        Task DeleteStateAsync(int id);
        Task<IEnumerable<ListStateDto>> GetListStatesWIncludesAsync();
        Task<GetStateDto> GetStateByIdAsync(int id);
        Task<IEnumerable<ListStateDto>> SearchState(string? searchStateName, int? selectedCityId);
        Task<GetStateDto> UpdateStateAsync(UpdateStateDto dto);
    }
}