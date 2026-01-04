using Microsoft.AspNetCore.Mvc;
using WPF.Services.Contracts;

namespace WPF.MVC.Controllers
{
    public class HomeController(IUserLogginService logging) : BaseController(logging)
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult NotFoundPage()
        {
            return View();
        }
    }
}
