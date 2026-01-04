using WPF.Models.Dtos.ShoppingCart;

namespace WPF.Services.Contracts
{
    public interface IShoppingCartServices
    {
        Task<bool> AddProductInCart(CreateShoppingCartDto dto, int userId);
        Task<IEnumerable<GetShoppingCartDto>> GetShoppingCartsForUser(int userId);
    }
}