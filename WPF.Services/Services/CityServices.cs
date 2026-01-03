using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Data;
using WPF.Models.Dtos.City;
using WPF.Models.Dtos.CityDtos;
using WPF.Models.Entities;
using WPF.Services.Contracts;

namespace WPF.Services.Services
{
    public class CityServices(ApplicationDbContext dbContext, IMapper mapper) : ICityServices
    {
        public async Task<IEnumerable<ListCityDto>> GetListCitiesWIncludesAsync()
        {
            var cities = await dbContext.Cities
                .Include(c => c.States)
                .Include(c => c.Country)
                .ToListAsync();
            var listCityDto = mapper.Map<IEnumerable<ListCityDto>>(cities);
            return listCityDto;
        }

        public async Task<GetCityDto> CreateCityAsync(CreateCityDto dto)
        {
            var City = mapper.Map<City>(dto);
            await dbContext.Cities.AddAsync(City);
            await dbContext.SaveChangesAsync();
            var getCityDto = mapper.Map<GetCityDto>(City);
            return getCityDto;
        }

        public async Task<GetCityDto> UpdateCityAsync(UpdateCityDto dto)
        {
            var City = await dbContext.Cities.FindAsync(dto.Id);
            mapper.Map(dto, City);
            await dbContext.SaveChangesAsync();
            var getCityDto = mapper.Map<GetCityDto>(City);
            return getCityDto;
        }

        public async Task DeleteCityAsync(int id)
        {
            var City = dbContext.Cities.Find(id);
            if (City != null) { }
            dbContext.Cities.Remove(City);
            await dbContext.SaveChangesAsync();
        }

        public async Task<GetCityDto> GetCityByIdAsync(int id)
        {
            var City = await dbContext.Cities.FindAsync(id);
            var dto = mapper.Map<GetCityDto>(City);
            return dto;
        }

        public async Task<IEnumerable<ListCityDto>> SearchCity(string? postalCode, string? name, int? countryId)
        {
            var query = dbContext.Cities
                .Include(c => c.Country)
                .Include(c => c.States)
                .AsQueryable();


            if (!string.IsNullOrWhiteSpace(name))
            {
                var searchName = name.Trim().ToUpper();
                query = query.Where(c => c.Name.ToUpper().Contains(searchName));
            }

            // 3. Posta kodu filtresi (Boþ deðilse filtrele)
            if (!string.IsNullOrWhiteSpace(postalCode))
            {
                var searchPost = postalCode.Trim();
                query = query.Where(c => c.PostalCode != null && c.PostalCode.Contains(searchPost));
            }

            // 4. Ülke filtresi (Seçilmiþse filtrele)
            if (countryId.HasValue && countryId > 0)
            {
                query = query.Where(c => c.CountryId == countryId.Value);
            }

            // 5. Sorguyu çalýþtýr ve listeyi çek
            var cities = await query.ToListAsync();

            // 6. DTO'ya dönüþtür ve gönder
            return mapper.Map<IEnumerable<ListCityDto>>(cities);
        }

    }
}
