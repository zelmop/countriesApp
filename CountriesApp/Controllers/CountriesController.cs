using CountriesApp.Models;
using CountriesApp.Services;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace CountriesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly CountryService _countryService;

        public CountriesController(CountryService countryService)
        {
            _countryService = countryService;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _countryService.GetAllCoutries());
        }

        // GET: api/Countries/name
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var country = await _countryService.GetCountry(name);
            
            if (country == null)
            {
                return new NotFoundResult();
            }
            else
            {
                return new ObjectResult(country);
            }
        }

        // POST: api/Countries
        [HttpPost]
        public ActionResult<Country> Post(Country country)
        {
            var newCountryDb = _countryService.Create(country);

            if (newCountryDb == null)
            {
                return StatusCode(500);
            }
            else
            {
                return StatusCode(201);
            }
        }

        // PUT: api/Countries/x
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody]Country country)
        {
            var countryFromDB = await _countryService.GetCountry(name);

            if (countryFromDB == null)
            {
                return new NotFoundResult();
            }
            else
            {
                country.Id = countryFromDB.Id;

                await _countryService.Update(country);

                return new OkObjectResult(country);
            }
        }

        // DELETE: api/Countries/x
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var countryFromDB = await _countryService.GetCountry(name);

            if (countryFromDB == null)
            {
                return new NotFoundResult();
            }
            else
            {
                await _countryService.Delete(name);

                return new OkResult();
            }
        }
    }
}
