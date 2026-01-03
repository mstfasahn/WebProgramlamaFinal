using Microsoft.AspNetCore.Mvc;

namespace WPF.MVC.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
