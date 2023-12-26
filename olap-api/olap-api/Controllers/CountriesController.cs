using Microsoft.AspNetCore.Mvc;
using olap_api.DTO;
using olap_api.Helper;
using olap_api.Models;
using olap_api.Repositories;

namespace olap_api.Controllers
{
    [ApiController]
    [Route("api/country")]
    public class CountriesController : Controller
    {
        private readonly ICountryRepository countryRepository;
        private readonly ILogger<CountriesController> logger;

        public CountriesController(ICountryRepository countryRepository, ILogger<CountriesController> logger)
        {
            this.logger = logger;
            this.countryRepository = countryRepository;
        }

        // Create  Country
        [HttpPost]
        public async Task<ActionResult<CountryDTO>> CreateCountry([FromBody] CreateCountryDTO request)
        {
            Country country = new()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Code = request.Code,
            };

            await countryRepository.CreateCountryAsync(country);
            return Ok(country.AsDto());
        }

        // Update Country
        [HttpPut]
        public async Task<ActionResult<CountryDTO>> UpdateCountry([FromQuery] Guid Id, [FromBody] UpdateCountryDTO request)
        {
            Country? existingEmployee = await countryRepository.GetCountryAsync(Id);
            if (existingEmployee == null)
            {
                return BadRequest("Record Not Found");
            }
            var updatedEmployee = await countryRepository.UpdateCountryAsync(existingEmployee, request);
            return Ok(updatedEmployee);
        }

        // Get Country
        [HttpGet]
        public async Task<ActionResult<CountryDTO>> GetCountry([FromQuery] Guid Id)
        {
            var existingCountry = await countryRepository.GetCountryAsync(Id);

            if (existingCountry == null)
            {
                return BadRequest("Record Not Found");
            }

            return Ok(existingCountry.AsDto());
        }

        // Get Countries
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<CountryDTO>>> GetAllCountries()
        {
            var countries = (await countryRepository.GetCountriesAsync()).Select(country => country.AsDto());
            return Ok(countries);
        }

        // Delete Country
        [HttpDelete]
        public async Task<ActionResult> DeleteCountry([FromQuery] Guid Id)
        {
            Country? existingCountry = await countryRepository.GetCountryAsync(Id);

            if (existingCountry == null)
            {
                return BadRequest("Record Not Found");
            }

            await countryRepository.DeleteCountryAsync(existingCountry);
            return Ok($"{existingCountry.Name} is deleted successfuly");

        }
    }
}
