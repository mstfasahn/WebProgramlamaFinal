using WPF.Models.Dtos.Country;
using WPF.Models.Dtos.CountryDtos;
using WPF.Models.Entities;

namespace WPF.Services.Contracts
{
    public interface ICountryService
    {
        Task<GetCountryDto> CreateCountryAsync(CreateCountryDto dto);
        Task DeleteCountryAsync(int id);
        Task<IEnumerable<Country>> GetCountriesAsync();
        Task<IEnumerable<ListCountryDto>> GetCountriesWCitiesAsync();
        Task<GetCountryDto> GetCountryByIdAsync(int id);
        Task<IEnumerable<ListCountryDto>> SearchCountry(string searchString);
        Task<GetCountryDto> UpdateCountryAsync(UpdateCountryDto dto);
    }
}