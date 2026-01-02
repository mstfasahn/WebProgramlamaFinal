using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Data;
using WPF.Models.Dtos.Carrier;
using WPF.Models.Entities;
using WPF.Services.Contracts;

namespace WPF.Services.Services
{
    public class CarrierService(ApplicationDbContext dbContext, IMapper mapper) : ICarrierService
    {
        public async Task<IEnumerable<GetCarrierDto>> GetCarriersAsync()
        {
            var carriers = await dbContext.Carriers.ToListAsync();
            var carriersDto = mapper.Map<IEnumerable<GetCarrierDto>>(carriers);
            return carriersDto;
        }

        public async Task<IEnumerable<GetCarrierDto>> GetCarrierBySearchAsync(string carrierName)
        {
            if (String.IsNullOrEmpty(carrierName)) 
            {
                var all = await dbContext.Carriers.ToListAsync();
                return mapper.Map<IEnumerable<GetCarrierDto>>(all);
            }
            var cleanedCarrierName = carrierName.Replace(" ", "").ToUpper();
            var carriers = await dbContext.Carriers
                    .Where(c => c.Name.Replace(" ", "").ToUpper().Contains(cleanedCarrierName))
                    .ToListAsync();
            return mapper.Map<IEnumerable<GetCarrierDto>>(carriers);
        }

        public async Task<GetCarrierDto> GetCarrierByIdAsync(int id)
        {
            var carrier = await dbContext.Carriers.FindAsync(id);
            return mapper.Map<GetCarrierDto>(carrier);
        }
        public async Task<GetCarrierDto> CreateCarrierAsync(CreateCarrierDto dto)
        {
            if (dto == null) { throw new ArgumentNullException(nameof(dto)); }
            var carrier = mapper.Map<Carrier>(dto);
            await dbContext.Carriers.AddAsync(carrier);
            await dbContext.SaveChangesAsync();
            var getCarrierDto = mapper.Map<GetCarrierDto>(carrier);
            return getCarrierDto;
        }

        public async Task<GetCarrierDto> UpdateCarrierAsync(UpdateCarrierDto dto)
        {
            if (dto == null) { throw new ArgumentNullException(nameof(dto)); }

            var carrierInDb = await dbContext.Carriers.FindAsync(dto.Id);

            if (carrierInDb == null)
            {

                throw new KeyNotFoundException("Güncellenecek taþýyýcý bulunamadý.");
            }
            mapper.Map(dto, carrierInDb);
            await dbContext.SaveChangesAsync();
            return mapper.Map<GetCarrierDto>(carrierInDb);
        }

        public async Task<bool> DeleteCarrierAsync(int id)
        {
            if (id == null) { return false; }
            var item = await dbContext.Carriers.FindAsync(id);
            if (item == null) { throw new KeyNotFoundException("Silinecek taþýyýcý bulunamadý."); }
            dbContext.Carriers.Remove(item);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
