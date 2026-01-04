using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WPF.Models.Dtos.State;
using WPF.MVC.Filters;
using WPF.MVC.ViewModels.State;
using WPF.Services.Contracts;
using WPF.Services.Services;

namespace WPF.MVC.Controllers
{
    [ServiceFilter(typeof(PermissionControlAttribute))]
    public class StateController
        (IStateServices stateServices,
        IMapper mapper, 
        ICityServices cityServices,
        IUserLogginService logging) : BaseController(logging)
    {
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var vm = new ListStateVM();
            var states = await stateServices.GetListStatesWIncludesAsync();
            var cities = await cityServices.GetListCitiesWIncludesAsync();
            var SlIcities = cities.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
            vm.States = states;
            vm.Cities = SlIcities;
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string? SearchStateName, int? SelectedCityId)
        {
            var vm = new ListStateVM();
            var states = await stateServices.SearchState(SearchStateName, SelectedCityId);
            var cities = await cityServices.GetListCitiesWIncludesAsync();
            var SLICities = cities.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });

            vm.States = states;
            vm.Cities = SLICities;
            return View("List",vm);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vm = new CreateStateVM();
            var cities = await cityServices.GetListCitiesWIncludesAsync();
            vm.Cities = cities.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStateVM vm)
        {
            var cities = await cityServices.GetListCitiesWIncludesAsync();

            var selectListItemCities = cities.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            if (vm.State == null)
            {
                vm.Cities = selectListItemCities;
                return View(vm);
            }
            if (ModelState.IsValid)
            {
                await stateServices.CreateStateAsync(vm.State);
                return RedirectToAction("List");

            }
            vm.Cities = selectListItemCities;
            return View(vm);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var cities = await cityServices.GetListCitiesWIncludesAsync();
            var selectListItemCities = cities.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            if (id <= 0 || id == null) { return RedirectToAction("List"); }

            var state = await stateServices.GetStateByIdAsync(id);
            if (state == null) { return RedirectToAction("List"); }
            var updateState = mapper.Map<UpdateStateDto>(state);

            var vm = new UpdateStateVM
            {
                State = updateState,
                Cities = selectListItemCities
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateStateVM vm)
        {
            if (vm.State == null) { return RedirectToAction("List"); }
            if (vm.State.Id <= 0) { return RedirectToAction("List"); }
            if (ModelState.IsValid)
            {
                await stateServices.UpdateStateAsync(vm.State);
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
            await stateServices.DeleteStateAsync(id);
            return RedirectToAction("List");
        }
    }
}

