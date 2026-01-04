using Microsoft.AspNetCore.Mvc;
using WPF.MVC.Filters;
using WPF.MVC.ViewModels.Permission;
using WPF.Services.Contracts;
using WPF.Services.Services;

namespace WPF.MVC.Controllers
{
    [ServiceFilter(typeof(PermissionControlAttribute))]
    public class PermissionController(
        IPermissionServices permissionServices,
        IUserLogginService logging) : BaseController(logging)
    {
        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            var data = await permissionServices.GetPermissionDataAsync();

            var vm = new ListPermissionVM
            {
                Endpoints = data.Endpoints,
                Roles = data.Roles,
                Permissions = data.Permissions
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePermission(int roleId, int endpointId, bool isActive)
        {
            var result = await permissionServices.UpdatePermissionAsync(roleId, endpointId, isActive);

            if (result)
            {
                return View("Manage", Json(new { success = true, message = "Yetki baþarýyla güncellendi." }));
            }

            return View("Manage",  Json(new { success = false, message = "Yetki güncellenirken bir hata oluþtu." }));
        }

    }
}
