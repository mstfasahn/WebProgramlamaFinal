using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WPF.Models.Dtos.Category;
using WPF.MVC.Filters;
using WPF.Services.Contracts;
using WPF.Services.Services;

namespace WPF.MVC.Controllers
{
    [ServiceFilter(typeof(PermissionControlAttribute))]
    public class CategoryController
        (ICategoryService categoryService,
        IMapper mapper,
        IUserLogginService logginService) : BaseController(logginService)
    {
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var categories= await categoryService.GetCategoryAsync();
            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> Search(string categoryName)
        {
            var category = await categoryService.GetCategoryBySearchAsync(categoryName);
            return View("List",category);

        }
        [HttpGet]
        public IActionResult Create() { return View(); }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto) 
        {
            if (dto == null) { return View(dto); }
            var category = await categoryService.CreateCategoryAsync(dto);
            return RedirectToAction("List", "Category");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) 
        {
            if (id == 0) { return View("List", "Category"); }
            var category =await categoryService.GetCategoryByIdAsync(id);
            var updateCategoryDto = mapper.Map<UpdateCategoryDto>(category);
            return View(updateCategoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCategoryDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await categoryService.UpdateCategoryAsync(dto);
            return RedirectToAction("List", "Category");
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) { RedirectToAction("List", "Category"); }
            await categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("List");
        }
    }
}
