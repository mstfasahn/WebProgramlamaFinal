using Microsoft.AspNetCore.Mvc;

namespace WPF.MVC.Controllers
{
    public class PermissionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
