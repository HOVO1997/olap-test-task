using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using olap_api.DTO;
using olap_api.Helper;
using olap_api.Models;
using olap_api.Repositories;

namespace olap_api.Controllers
{
    [ApiController]
    [Route("api/dataPoint")]
    public class DataPointsController : Controller
    {
        private readonly IDataPointRpository dataPointRpository;
        private readonly IIndicatorRepository indicatorRepository;
        private readonly ICountryRepository countryRepository;
        private readonly ILogger<DataPointsController> logger;

        public DataPointsController(
            IDataPointRpository dataPointRpository,
            IIndicatorRepository indicatorRepository,
            ICountryRepository countryRepository,
            ILogger<DataPointsController> logger)
        {
            this.logger = logger;
            this.dataPointRpository = dataPointRpository;
            this.indicatorRepository = indicatorRepository;
            this.countryRepository = countryRepository;
        }

        // Create DataPoint
        [HttpPost]
        public async Task<ActionResult<DataPointDTO>> CreateCountry([FromBody] CreateDataPointDTO userRequest)
        {
            Country? existingCountry = await countryRepository.GetCountryAsync(userRequest.CountryId);
            Indicator? existingIndicator = await indicatorRepository.GetIndicatorAsync(userRequest.IndicatorId);

            if (existingCountry == null || existingIndicator == null)
            {
                return BadRequest("Record Not Found");
            }

            DataPoint dataPoint = new()
            {
                Id = Guid.NewGuid(),
                Countries = existingCountry,
                Indicators = existingIndicator,
                Frequency = userRequest.Frequency,
                Date = userRequest.Date,
                Value = userRequest.Value,
            };

            await dataPointRpository.CreateDataPointAsync(dataPoint);
            return Ok(dataPoint);
        }

        // Update DataPoint
        [HttpPut]
        public async Task<ActionResult<DataPointDTO>> UpdateDataPoint([FromQuery] Guid Id, [FromBody] UpdateDataPointDTO request)
        {
            DataPoint? existingDataPoint = await dataPointRpository.GetDataPointAsync(Id);
            Country? existingCountry = await countryRepository.GetCountryAsync(request.CountryId);
            Indicator? existingIndicator = await indicatorRepository.GetIndicatorAsync(request.IndicatorId);

            if (existingDataPoint == null || existingCountry == null || existingIndicator == null)
            {
                return BadRequest("Record Not Found");
            }
            var updatedDataPoint = await dataPointRpository.UpdateDataPointAsync(existingDataPoint, existingCountry, existingIndicator, request);
            return Ok(updatedDataPoint);
        }

        // Get DataPoint
        [HttpGet]
        public async Task<ActionResult<DataPointDTO>> GetDataPoint([FromQuery] Guid Id)
        {
            var existingDataPoint = await dataPointRpository.GetDataPointAsync(Id);

            if (existingDataPoint == null)
            {
                return BadRequest("Record Not Found");
            }

            return Ok(existingDataPoint);
        }

        // Get DataPoints
        [HttpGet("all")]
        public async Task<ActionResult<object>> GetDataPoints()
        {
            var dataPoints = await dataPointRpository.GetDataPointsAsync();
            return Ok(dataPoints);
        }

        // Delete Country
        [HttpDelete]
        public async Task<ActionResult> DeleteDataPoint([FromQuery] Guid Id)
        {
            DataPoint? existingDataPoint = await dataPointRpository.GetDataPointAsync(Id);

            if (existingDataPoint == null)
            {
                return BadRequest("Record Not Found");
            }

            await dataPointRpository.DeleteDataPointAsync(existingDataPoint);
            return Ok($"{existingDataPoint.Id} is deleted successfuly");
        }
    }
}
