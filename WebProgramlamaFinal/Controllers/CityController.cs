using Microsoft.AspNetCore.Mvc;

namespace WPF.MVC.Controllers
{
    public class CityController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
