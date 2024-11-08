using Microsoft.AspNetCore.Mvc;
using Ratings.API.Model;
using Ratings.API.Services;

namespace Ratings.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingsController : ControllerBase
    {
        private readonly ILogger<RatingsController> _logger;
        private readonly IRatingReportBuilderService _ratingReportBuilder;

        public RatingsController(ILogger<RatingsController> logger, IRatingReportBuilderService ratingReportBuilder)
        {
            _logger = logger;
            _ratingReportBuilder = ratingReportBuilder;
        }

        //TODO Check how this should be names for REST API
        // Could allow some filter here if required at a later stage
        [HttpGet(Name = "instrumentratings")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ratingData = await _ratingReportBuilder.GetData();

                if(ratingData is null || !ratingData.Any()) // Nice extension method for this in a Core library :)
                    return NotFound();

                return Ok(ratingData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error getting InstrumentRatings");
                return StatusCode(500, "An unexpected error occurred whilst retrieving Instrument Ratings");
            }
        }
    }
}
