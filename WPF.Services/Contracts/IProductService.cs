using WPF.Models.Dtos.Product;

namespace WPF.Services.Contracts
{
    public interface IProductService
    {
        Task CreateProductAsync(CreateProductDto dto, int currentUserId);
        Task<bool> DeleteProductAsync(int id, int userId, int RoleId);
        Task<IEnumerable<GetProductDto>> GetAllPublicProductsAsync();
        Task<IEnumerable<GetProductDto>> GetManagementProductsAsync(int currentUserId, int roleId);
        Task<UpdateProductDto> GetProductForUpdateAsync(int id, int userId, int roleId);
        Task UpdateProductAsync(UpdateProductDto dto);
    }
}