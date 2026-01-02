using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Text.Json;
using WPF.Data;
using WPF.Models.Dtos.User;
using WPF.Models.Entities;
using WPF.Services.Contracts;

namespace WPF.MVC.Controllers
{
    public class BaseController(IUserLogginService loggingService) : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userJson = HttpContext.Session.GetString("CurrentUser");

            if (userJson == null)
            {
                filterContext.Result = RedirectToAction("Login", "User");
                return;
            }

            var session = JsonConvert.DeserializeObject<GetUserDto>(userJson);

            var ReqController = filterContext.RouteData.Values["controller"]?.ToString();
            var ReqAction = filterContext.RouteData.Values["action"]?.ToString();
            var ReqIp = filterContext.HttpContext.Connection.RemoteIpAddress?.ToString();

            loggingService.LogAsync(session.Id, ReqController, ReqAction, ReqIp).Wait();
            base.OnActionExecuting(filterContext);
        }
    }
}
