using WPF.Models.Dtos.Carrier;

namespace WPF.Services.Contracts
{
    public interface ICarrierService
    {
        Task<GetCarrierDto> CreateCarrierAsync(CreateCarrierDto dto);
        Task<bool> DeleteCarrierAsync(int id);
        Task<IEnumerable<GetCarrierDto>> GetCarrierBySearchAsync(string carrierName);
        Task<GetCarrierDto> GetCarrierByIdAsync(int id);
        Task<IEnumerable<GetCarrierDto>> GetCarriersAsync();
        Task<GetCarrierDto> UpdateCarrierAsync(UpdateCarrierDto dto);
    }
}