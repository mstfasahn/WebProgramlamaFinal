using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WPF.Models.Dtos.User;
using WPF.MVC.ViewModels;
using WPF.Services.Contracts;
using WPF.Services.Services;

namespace WPF.MVC.Controllers
{
    public class ProductController
        (ICategoryService categoryService,
        IProductService productService,
        IUserService userService,
        IUserLogginService logging) : BaseController(logging)
    {
        [HttpGet]
        public IActionResult Create() { return View(); }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductVM vm)
        {
            // 1. Session'dan kullanýcýyý al
            var userJson = HttpContext.Session.GetString("CurrentUser");
            if (string.IsNullOrEmpty(userJson)) return RedirectToAction("Login", "User");

            var currentUser = JsonConvert.DeserializeObject<GetUserDto>(userJson);
            if (string.IsNullOrEmpty(currentUser.ToString())) { return RedirectToAction("Login", "User"); }
            
            if (ModelState.IsValid)
            {
                
                await productService.CreateProductAsync(vm.CreateProductDto, currentUser.Id);

                TempData["success"] = "Ürün baþarýyla eklendi.";
                return RedirectToAction(nameof(Index));
            }

            vm.Categories = await categoryService.GetCategoryAsync();
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> ManagementList()
        {
            var userJson = HttpContext.Session.GetString("CurrentUser");
            if (string.IsNullOrEmpty(userJson)) return RedirectToAction("Login", "User");
            var currentUser = JsonConvert.DeserializeObject<GetUserDto>(userJson);
            if (string.IsNullOrEmpty(currentUser.ToString())) { return RedirectToAction("Login", "User"); }

            var result = await userService.IsAValidRequest(currentUser.Id,currentUser.RoleId);
            if (!result) { return RedirectToAction("AccessDenied", "User"); }

            var products = await productService.GetManagementProductsAsync(currentUser.Id,currentUser.RoleId);
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> PublicList()
        {
            var products=await productService.GetAllPublicProductsAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) 
        {
            var userJson = HttpContext.Session.GetString("CurrentUser");
            if (string.IsNullOrEmpty(userJson)) return RedirectToAction("Login", "User");
            var currentUser = JsonConvert.DeserializeObject<GetUserDto>(userJson);
            var result = await userService.IsAValidRequest(currentUser.Id,currentUser.RoleId);
            if (!result) { return RedirectToAction("AccessDenied", "User"); }
            var product =await productService.GetProductForUpdateAsync(id,currentUser.Id,currentUser.RoleId);

            if (product == null) { return RedirectToNotFound(); }
            var categories = await categoryService.GetCategoryAsync();

            var viewModel = new UpdateProductVM
            {
                Product = product,
                CategoryList = (categories.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }))
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProductVM vm) 
        {
            if (ModelState.IsValid)
            {
                await productService.UpdateProductAsync(vm.Product);
                TempData["success"] = "Ürün baþarýyla güncellendi.";
                return RedirectToAction("ManagementList", "Product");
            }
            var categories = await categoryService.GetCategoryAsync();
            vm.CategoryList = categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
            TempData["fault"] = "Lütfen tekrar deneyiniz.";
            return View(vm);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id) 
        {
            var userJson = HttpContext.Session.GetString("CurrentUser");
            var currentUser = JsonConvert.DeserializeObject<GetUserDto>(userJson);
            if (currentUser == null) { return RedirectToLogin(); }
            if(currentUser.Id<=0 || currentUser.RoleId<=0) { return RedirectToAccessDenied(); }

            var result = await userService.IsAValidRequest(currentUser.Id, currentUser.RoleId);
            if (!result) { RedirectToAccessDenied();}
            
            var IsDeleted = await productService.DeleteProductAsync(id,currentUser.Id, currentUser.RoleId);

            if (!IsDeleted) { RedirectToAction("Edit", "Product", id);}
            return RedirectToAction("ManagementList","Product");
        }
    }
}
