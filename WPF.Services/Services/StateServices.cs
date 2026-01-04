using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Data;
using WPF.Models.Dtos.State;
using WPF.Models.Dtos.StateDtos;
using WPF.Models.Entities;
using WPF.Services.Contracts;

namespace WPF.Services.Services
{
    public class StateServices(ApplicationDbContext dbContext, IMapper mapper) : IStateServices
    {
        public async Task<IEnumerable<ListStateDto>> GetListStatesWIncludesAsync()
        {
            var States = await dbContext.States
                .Include(c => c.City)
                .ToListAsync();
            var listStateDto = mapper.Map<IEnumerable<ListStateDto>>(States);
            return listStateDto;
        }

        public async Task<GetStateDto> CreateStateAsync(CreateStateDto dto)
        {
            var State = mapper.Map<State>(dto);
            await dbContext.States.AddAsync(State);
            await dbContext.SaveChangesAsync();
            var getStateDto = mapper.Map<GetStateDto>(State);
            return getStateDto;
        }

        public async Task<GetStateDto> UpdateStateAsync(UpdateStateDto dto)
        {
            var State = await dbContext.States.FindAsync(dto.Id);
            mapper.Map(dto, State);
            await dbContext.SaveChangesAsync();
            var getStateDto = mapper.Map<GetStateDto>(State);
            return getStateDto;
        }

        public async Task DeleteStateAsync(int id)
        {
            var State = dbContext.States.Find(id);
            if (State != null) { }
            dbContext.States.Remove(State);
            await dbContext.SaveChangesAsync();
        }

        public async Task<GetStateDto> GetStateByIdAsync(int id)
        {
            var State = await dbContext.States.FindAsync(id);
            var dto = mapper.Map<GetStateDto>(State);
            return dto;
        }

        public async Task<IEnumerable<ListStateDto>> SearchState(string? searchStateName, int? selectedCityId)
        {
            // 1. Sorguyu hazýrlýyoruz ve Þehir bilgisini (CityName için) dahil ediyoruz
            var query = dbContext.States
                .Include(s => s.City)
                .AsQueryable();

            // 2. Ýlçe Adýna göre filtrele (Boþ deðilse)
            if (!string.IsNullOrWhiteSpace(searchStateName))
            {
                var search = searchStateName.Trim().ToUpper();
                query = query.Where(s => s.Name.ToUpper().Contains(search));
            }

            // 3. Seçilen Þehre göre filtrele (0'dan büyük bir ID seçilmiþse)
            if (selectedCityId.HasValue && selectedCityId > 0)
            {
                query = query.Where(s => s.CityId == selectedCityId.Value);
            }

            // 4. Veritabanýndan veriyi çek
            var states = await query.ToListAsync();

            // 5. AutoMapper ile DTO'ya dönüþtür
            return mapper.Map<IEnumerable<ListStateDto>>(states);
        }

    }
}

