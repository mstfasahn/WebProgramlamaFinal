using Microsoft.AspNetCore.Mvc;
using WPF.Models.Dtos.User;
using WPF.Services.Contracts;
using WPF.Services.Implementations;

namespace WPF.MVC.Controllers
{
    public class UserController(IAuthService authService) : Controller
    {

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            if (!ModelState.IsValid) return View(loginDto);

            var userDto = await authService.LoginAsync(loginDto);

            if (userDto != null)
            {
                // Nesneyi JSON string'e çevirip Session'a atýyoruz
                var userJson = System.Text.Json.JsonSerializer.Serialize(userDto);
                HttpContext.Session.SetString("CurrentUser", userJson);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "E-posta veya þifre hatalý.");
            return View(loginDto);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}
