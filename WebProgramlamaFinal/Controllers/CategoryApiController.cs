using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WPF.Models.Dtos.Country;
using WPF.Services.Contracts;

namespace WPF.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryApiController(
        ICountryService countryService,
        IMapper mapper) : ControllerBase 
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await countryService.GetCountriesWCitiesAsync();
            return Ok(data); 
        }

        //GET: api/country/search?searchString=tur
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string searchString)
        {
            if (string.IsNullOrEmpty(searchString)) return BadRequest("Arama ifadesi boþ olamaz.");

            var countries = await countryService.SearchCountry(searchString);
            return Ok(countries);
        }

        //GET: api/country/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var country = await countryService.GetCountryByIdAsync(id);
            if (country == null) return NotFound($"{id} numaralý ülke bulunamadý.");

            return Ok(country);
        }

        //POST: api/country
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCountryDto dto)
        {
            if (dto == null) return BadRequest("Veri boþ olamaz.");

            var result = await countryService.CreateCountryAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        //PUT: api/country/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCountryDto dto)
        {
            if (id != dto.Id) return BadRequest("URL'deki ID ile nesne içindeki ID uyuþmuyor.");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            await countryService.UpdateCountryAsync(dto);
            return NoContent(); 
        }

        //DELETE: api/country/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var country = await countryService.GetCountryByIdAsync(id);
            if (country == null) return NotFound();

            await countryService.DeleteCountryAsync(id);
            return Ok(new { message = "Ülke baþarýyla silindi." });
        }
    }
}