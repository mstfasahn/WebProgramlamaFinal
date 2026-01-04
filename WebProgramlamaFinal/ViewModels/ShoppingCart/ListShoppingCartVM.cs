using WPF.Models.Dtos.ShoppingCart;

namespace WPF.MVC.ViewModels.ShoppingCart
{
    public class ListShoppingCartVM
    {
        public IEnumerable<GetShoppingCartDto> CartItems { get; set; } = new List<GetShoppingCartDto>();

        public double OrderTotal { get; set; }
    }
}
