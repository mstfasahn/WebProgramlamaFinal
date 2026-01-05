using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WPF.Models.Dtos.ShoppingCart;
using WPF.Models.Dtos.User;
using WPF.MVC.Filters;
using WPF.MVC.ViewModels.ShoppingCart;
using WPF.Services.Contracts;

namespace WPF.MVC.Controllers
{
    [ServiceFilter(typeof(PermissionControlAttribute))]
    public class ShoppingCartController
        (
        IShoppingCartServices cartServices,
        IMapper mapper,
        IUserLogginService logging
        ) : BaseController(logging)
    {
        public async Task<IActionResult> AddAndRedirect(int productId)
        {
            if (productId == 0) { return RedirectToNotFound(); }
            //Kullanýcý verisi alýndý
            var userJson = HttpContext.Session.GetString("CurrentUser");
            if (string.IsNullOrEmpty(userJson))
            {
                return RedirectToLogin(); ;
            }
            var currentUser = JsonConvert.DeserializeObject<GetUserDto>(userJson);

            var cartDto = new CreateShoppingCartDto
            {
                ProductId = productId,
                Count = 1 
            };
            var result = await cartServices.AddProductInCart(cartDto, currentUser.Id);
            if (result) {return  RedirectToCart(); }

            TempData["error"] = "Ürün sepete eklenirken bir hata oluþtu.";
            return RedirectToPublicProductList();
        }

        public async Task<IActionResult> MyCart()
        {
            //Kullanýcý verisi alýndý
            var userJson = HttpContext.Session.GetString("CurrentUser");
            if (string.IsNullOrEmpty(userJson))
            {
                return RedirectToLogin(); ;
            }
            var currentUser = JsonConvert.DeserializeObject<GetUserDto>(userJson);
            var cartsItems = await cartServices.GetShoppingCartsForUser(currentUser.Id);
            double totalAmount = cartsItems.Sum(c => c.LinePrice);

            var vm = new ListShoppingCartVM { CartItems = cartsItems, OrderTotal = totalAmount };
            return View(vm);
        }

        public async Task<IActionResult> UpdateQuantity(int productId, int countChange)
        {
            var userJson = HttpContext.Session.GetString("CurrentUser");
            if (string.IsNullOrEmpty(userJson)) return Json(new { success = false });

            var currentUser = JsonConvert.DeserializeObject<GetUserDto>(userJson);

            var dto = new CreateShoppingCartDto
            {
                ProductId = productId,
                Count = countChange
            };

            var result = await cartServices.AddProductInCart(dto, currentUser.Id);
            return RedirectToCart();
        }
    }
}