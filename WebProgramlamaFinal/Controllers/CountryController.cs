using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WPF.Models.Dtos.Country;
using WPF.MVC.Filters;
using WPF.MVC.ViewModels;
using WPF.Services.Contracts;

namespace WPF.MVC.Controllers
{
    [ServiceFilter(typeof(PermissionControlAttribute))]

    public class CountryController(ICountryService countryService,
        IUserLogginService logging,
        IMapper mapper) : BaseController(logging)
    {
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var data= await countryService.GetCountriesWCitiesAsync();

            var VM = new ListCountryVM { Countries = data };
            return View(VM);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchString)
        {
            if (string.IsNullOrEmpty(searchString)) {  return View("List"); }
            var countries= await countryService.SearchCountry(searchString);

            var VM= new ListCountryVM {  Countries=countries,SearchString=searchString };
            return View("List",VM);
        }   

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0) { RedirectToNotFound(); }
            var country= await countryService.GetCountryByIdAsync(id);
            if (country == null) { RedirectToNotFound(); }
            var updateDto= mapper.Map<UpdateCountryDto>(country);
            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCountryDto dto)
        {
            if (dto == null) { return RedirectToAction("List"); }
            if(dto.Id<=0) { RedirectToNotFound(); }
            if (ModelState.IsValid)
            {
               var data= await countryService.UpdateCountryAsync(dto);
                TempData["Succesful"] = "Baþarýyla Güncellendi";
                return RedirectToAction("List");
                
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCountryDto dto)
        {
            if (dto == null)
            {
                TempData["Failed"] = "Boþ nesne gönderilemez."; 
                return RedirectToAction("List"); 
            }
            if (ModelState.IsValid) 
            { 
            
                var data = await countryService.CreateCountryAsync(dto);
                TempData["Succesful"] = "Baþarýyla Kayýt edildi.";
                return RedirectToAction("List");

            }
            TempData["Fault"] = "Bir Þeyler Ters Gitti.";

            return RedirectToAction("List");

        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) { RedirectToNotFound(); }
            await countryService.DeleteCountryAsync(id);
            return RedirectToAction("List");
        }


    }
}
