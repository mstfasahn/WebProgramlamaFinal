using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WPF.Models.Dtos.City;
using WPF.MVC.Filters;
using WPF.MVC.ViewModels.City;
using WPF.Services.Contracts;

namespace WPF.MVC.Controllers
{
    [ServiceFilter(typeof(PermissionControlAttribute))]

    public class CityController
        (ICityServices cityServices,
        IMapper mapper,
        ICountryService countryService,
        IUserLogginService logging) : BaseController(logging)
    {
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var vm = new ListCityVM();
            var cities = await cityServices.GetListCitiesWIncludesAsync();
            var countries = await countryService.GetCountriesAsync();
            var SlIcountries = countries.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
            vm.Cities = cities;
            vm.CountryList = SlIcountries;
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string? SearchName, string? SearchPostalCode, int? SelectedCountryId) 
        {
            var vm = new ListCityVM();
            var cities= await cityServices.SearchCity(SearchName, SearchPostalCode, SelectedCountryId);
            var countries = await countryService.GetCountriesAsync();
            var SLICoumtries = countries.Select(c => new SelectListItem {Text=c.Name,Value=c.Id.ToString() });

            vm.Cities = cities;
            vm.CountryList = SLICoumtries;
            return View("List",vm);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vm = new CreateCityVM();
            var countries = await countryService.GetCountriesAsync();
            vm.CountryList = countries.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCityVM vm)
        {
            var countries = await countryService.GetCountriesAsync();

            var selectListItemCountries = countries.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            if (vm.City == null)
            {
                vm.CountryList = selectListItemCountries;
                return View(vm);
            }
            if (ModelState.IsValid)
            {
                await cityServices.CreateCityAsync(vm.City);
                return RedirectToAction("List");

            }
            vm.CountryList = selectListItemCountries;
            return View(vm);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var countries = await countryService.GetCountriesAsync();
            var selectListItemCountries = countries.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            if (id <= 0 || id == null) { return RedirectToAction("List"); }

            var city = await cityServices.GetCityByIdAsync(id);
            if (city == null) { return RedirectToAction("List"); }
            var updateCity = mapper.Map<UpdateCityDto>(city);

            var vm = new UpdateCityVM
            {
                City = updateCity,
                Countries = selectListItemCountries
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCityVM vm)
        {
            if (vm.City == null) { return RedirectToAction("List"); }
            if (vm.City.Id <= 0) { return RedirectToAction("List"); }
            if (ModelState.IsValid)
            {
                await cityServices.UpdateCityAsync(vm.City);
                TempData["Succes"] = "Baþarýyla Güncellendi.";

                return RedirectToAction("List");
            }
            TempData["Fault"] = "Beklenmeyen bir sorun oluþtu.";
            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("List");

            }
            await cityServices.DeleteCityAsync(id);
            return RedirectToAction("List");
        }
    }
}