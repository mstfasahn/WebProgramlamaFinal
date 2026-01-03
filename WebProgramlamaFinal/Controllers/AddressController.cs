using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WPF.Data;

namespace WPF.MVC.Controllers
{
    [Route("api/[controller]")]
    public class AddressController(ApplicationDbContext dbContext) : Controller
    {


        [HttpGet("GetCities/{countryId}")]
        public async Task<IActionResult> GetCities(int countryId)
        {
            var cities = await dbContext.Cities.Where(c => c.CountryId == countryId).ToListAsync();
            return Ok(cities);
        }

        [HttpGet("GetStates/{cityId}")]
        public async Task<IActionResult> GetStates(int cityId)
        {
            var states = await dbContext.States.Where(s => s.CityId == cityId).ToListAsync();
            return Ok(states);
        }
    }
}
