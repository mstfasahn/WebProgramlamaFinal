using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Data;
using WPF.Models.Dtos.Country;
using WPF.Models.Dtos.CountryDtos;
using WPF.Models.Entities;
using WPF.Services.Contracts;

namespace WPF.Services.Services
{
    public class CountryService(ApplicationDbContext dbContext, IMapper mapper) : ICountryService
    {
        public async Task<IEnumerable<GetCountryDto>> GetCountriesAsync()
        {
            var countries= await dbContext.Countries.AsNoTracking().ToListAsync();
            var countryDto= mapper.Map<IEnumerable<GetCountryDto>>(countries);
            return countryDto;
        }

        public async Task<IEnumerable<ListCountryDto>> SearchCountry(string searchString)
        {
            var searchKeyword = searchString.Trim().ToUpper();

            var countries = await dbContext.Countries
                .Include(c => c.Cities) // Þehirleri unutma!
                .Where(c => c.Name.ToUpper().Contains(searchKeyword))
                .ToListAsync();

            return mapper.Map<IEnumerable<ListCountryDto>>(countries);
        }
        public async Task<IEnumerable<ListCountryDto>> GetCountriesWCitiesAsync()
        {
            var countries= await dbContext.Countries.Include(c => c.Cities).ToListAsync();
            var dto= mapper.Map<IEnumerable<ListCountryDto>>(countries);
            return dto;
        }
        public async Task<GetCountryDto> CreateCountryAsync(CreateCountryDto dto)
        {
            var country = mapper.Map<Country>(dto);
            await dbContext.Countries.AddAsync(country);
            await dbContext.SaveChangesAsync();
            var getCountryDto = mapper.Map<GetCountryDto>(country);
            return getCountryDto;
        }

        public async Task<GetCountryDto> UpdateCountryAsync(UpdateCountryDto dto)
        {
            var country = await dbContext.Countries.FindAsync(dto.Id);
            mapper.Map(dto, country);
            await dbContext.SaveChangesAsync();
            var getCountryDto = mapper.Map<GetCountryDto>(country);
            return getCountryDto;
        }

        public async Task DeleteCountryAsync(int id)
        {
            var country = dbContext.Countries.Find(id);
            if (country != null) { }
            dbContext.Countries.Remove(country);
            await dbContext.SaveChangesAsync();

        }

        public async Task<GetCountryDto> GetCountryByIdAsync(int id)
        {
            var country=await dbContext.Countries.FindAsync(id);
            var dto= mapper.Map<GetCountryDto>(country);


            return dto;
        }
    }
}
