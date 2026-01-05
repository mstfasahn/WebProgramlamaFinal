using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Text.Json;
using System.Threading.Tasks;
using WPF.Data;
using WPF.Models.Dtos.User;
using WPF.Models.Entities;
using WPF.Services.Contracts;

namespace WPF.MVC.Controllers
{
    public class BaseController(IUserLogginService loggingService) : Controller
    {
        // "Executing" deðil "Execution" olmalý çünkü async programlýyoruz.
        public override async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            var ReqController = filterContext.RouteData.Values["controller"]?.ToString();
            var ReqAction = filterContext.RouteData.Values["action"]?.ToString();
            var ReqIp = filterContext.HttpContext.Connection.RemoteIpAddress?.ToString();

            var userJson = HttpContext.Session.GetString("CurrentUser");

            if (string.IsNullOrEmpty(userJson))
            {
                // Login olmamýþ kullanýcý logu
                await loggingService.LogAsync(1, ReqController, ReqAction, ReqIp);
                await next();
                return;
            }

            var user = JsonConvert.DeserializeObject<GetUserDto>(userJson);
            await loggingService.LogAsync(user.Id, ReqController, ReqAction, ReqIp);

            // Bu satýr asenkron akýþýn devam etmesini saðlar
            await next();


        }

        protected IActionResult RedirectToNotFound()
        {
            Response.StatusCode = 404;
            return RedirectToAction("NotFoundPage", "Home");
        }
        protected IActionResult RedirectToAccessDenied()
        {
            Response.StatusCode = 403;
            return RedirectToAction("AccessDenied", "Home");
        }
        protected IActionResult RedirectToLogin()
        {
            Response.StatusCode = 403;
            return RedirectToAction("Login", "User");
        }
        protected IActionResult RedirectToCart()
        {
            return RedirectToAction("MyCart", "ShoppingCart");
        }
        protected IActionResult RedirectToPublicProductList()
        {
            return RedirectToAction("PublicList", "Product");

        }
        protected IActionResult RedirectToCategoryList()
        {
            return RedirectToAction("List","Category");

        }
        protected GetUserDto CurrentUser =>
        JsonConvert.DeserializeObject<GetUserDto>(HttpContext.Session.GetString("CurrentUser"));
    }
}
