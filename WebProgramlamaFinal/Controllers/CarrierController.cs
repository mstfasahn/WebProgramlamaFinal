using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WPF.Models.Dtos.Carrier;
using WPF.MVC.Filters;
using WPF.Services.Contracts;
using WPF.Services.Services;

namespace WPF.MVC.Controllers
{
    [ServiceFilter(typeof(PermissionControlAttribute))]
    public class CarrierController
        (ICarrierService carrierService,IMapper mapper,IUserLogginService logginService) : BaseController(logginService)
    {
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var carriers = await carrierService.GetCarriersAsync();
            return View(carriers);
        }
        [HttpGet]
        //[Route("Carrier/List/{carriername}")]
        public async Task<IActionResult> Search(string carriername)
        {
            var carriers = await carrierService.GetCarrierBySearchAsync(carriername);
            return View("List",carriers);
        }
        [HttpGet]
        public  IActionResult Create() { return View(); }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCarrierDto dto)
        {
            if (dto == null) { return View(dto); }

            var data= await carrierService.CreateCarrierAsync(dto);
            return RedirectToAction("List","Carrier");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0) { return View("List", "Carrier"); }
            var carrier = await carrierService.GetCarrierByIdAsync(id);
            var updateDto = mapper.Map<UpdateCarrierDto>(carrier);
            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCarrierDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await carrierService.UpdateCarrierAsync(dto);
            return RedirectToAction("List","Carrier");
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await carrierService.DeleteCarrierAsync(id);
            return RedirectToAction("List");
        }
    }
}
