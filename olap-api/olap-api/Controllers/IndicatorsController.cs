using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using olap_api.DTO;
using olap_api.Helper;
using olap_api.Models;
using olap_api.Repositories;

namespace olap_api.Controllers
{
    [ApiController]
    [Route("api/indicator")]
    public class IndicatorsController : Controller
    {
        private readonly IIndicatorRepository indicatorRepository;
        private readonly ILogger<IndicatorsController> logger;

        public IndicatorsController(IIndicatorRepository indicatorRepository, ILogger<IndicatorsController> logger)
        {
            this.logger = logger;
            this.indicatorRepository = indicatorRepository;
        }

        // Create  Indicator
        [HttpPost]
        public async Task<ActionResult<IndicatorDTO>> CreateIndicator([FromBody] CreateIndicatorDTO userRequest)
        {
            Indicator indicator = new()
            {
                Id = Guid.NewGuid(),
                Name = userRequest.Name,
                Code = userRequest.Code,
            };

            await indicatorRepository.CreateIndicatorAsync(indicator);
            return Ok(indicator.AsDto());
        }

        // Update Country
        [HttpPut]
        public async Task<ActionResult<IndicatorDTO>> UpdateIndicator([FromQuery] Guid Id, [FromBody] UpdateIndicatorDTO request)
        {
            Indicator? existingIndicator = await indicatorRepository.GetIndicatorAsync(Id);
            if (existingIndicator == null)
            {
                return BadRequest("Record Not Found");
            }
            var updatedIndicator = await indicatorRepository.UpdateIndicatorAsync(existingIndicator, request);
            return Ok(updatedIndicator);
        }

        // Get Indicator
        [HttpGet]
        public async Task<ActionResult<IndicatorDTO>> GetIndicator([FromQuery] Guid Id)
        {
            var existingIndicator = await indicatorRepository.GetIndicatorAsync(Id);

            if (existingIndicator == null)
            {
                return BadRequest("Record Not Found");
            }

            return Ok(existingIndicator.AsDto());
        }

        // Get Indicators
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<IndicatorDTO>>> GetAllIndicators()
        {
            var indicators = (await indicatorRepository.GetIndicatorsAsync()).Select(indicator => indicator.AsDto());
            return Ok(indicators);
        }

        // Delete Indicator
        [HttpDelete]
        public async Task<ActionResult> DeleteIndicator([FromQuery] Guid Id)
        {
            Indicator? existingIndicator = await indicatorRepository.GetIndicatorAsync(Id);

            if (existingIndicator == null)
            {
                return BadRequest("Record Not Found");
            }

            await indicatorRepository.DeleteIndicatorAsync(existingIndicator);
            return Ok($"{existingIndicator.Name} is deleted successfuly");

        }
    }
}
