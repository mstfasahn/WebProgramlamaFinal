using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;
using WPF.Data;
using WPF.Models.Dtos.User;

namespace WPF.MVC.Filters
{
    public class PermissionControlAttribute(ApplicationDbContext dbContext) : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // 1. Session'dan kullanýcýyý al
            var userJson = context.HttpContext.Session.GetString("CurrentUser");

            if (string.IsNullOrEmpty(userJson))
            {
                // Giriþ yapýlmamýþsa Login'e gönder
                context.Result = new RedirectToActionResult("Login", "User", null);
                return;
            }

            var user = JsonSerializer.Deserialize<GetUserDto>(userJson);
            //Admin ise hýzlýca devam edebilir
            if (user.RoleId == 1)
            {
                base.OnActionExecuting(context);
                return;
            }
            // 2. Gidilmek istenen Controller ve Action adlarýný yakala
            var controllerName = context.RouteData.Values["controller"]?.ToString();
            var actionName = context.RouteData.Values["action"]?.ToString();

            // 3. Veritabanýna eriþ
   
                // 4. Yetki Kontrolü: DB'de bu Rol ve bu Endpoint için aktif izin var mý?
                var hasPermission = dbContext.Permissions
                   .Any(p => p.RoleId == user.RoleId &&
                             p.Endpoint.ControllerName == controllerName &&
                             p.Endpoint.ActionName == actionName &&
                             p.IsActive);

            if (!hasPermission)
            {
                // Index yerine AccessDenied sayfasýna gönderiyoruz
                context.Result = new RedirectToActionResult("AccessDenied", "Home", null);
                return;
            }


            base.OnActionExecuting(context);
        }
    }
}

