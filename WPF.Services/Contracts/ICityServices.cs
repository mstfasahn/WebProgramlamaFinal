using WPF.Models.Dtos.City;
using WPF.Models.Dtos.CityDtos;

namespace WPF.Services.Contracts
{
    public interface ICityServices
    {
        Task<GetCityDto> CreateCityAsync(CreateCityDto dto);
        Task DeleteCityAsync(int id);
        Task<GetCityDto> GetCityByIdAsync(int id);
        Task<IEnumerable<ListCityDto>> GetListCitiesWIncludesAsync();
        Task<IEnumerable<ListCityDto>> SearchCity(string? postalCode, string? name, int? countryId);
        Task<GetCityDto> UpdateCityAsync(UpdateCityDto dto);

    }
}