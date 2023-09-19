using Demo.Api.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForcastService _weatherForcastService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IWeatherForcastService _weatherForcastService, ILogger<WeatherForecastController> logger)
        {
            this._weatherForcastService = _weatherForcastService ?? throw new ArgumentNullException(nameof(_weatherForcastService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        /// <summary>
        /// Get list Weather Details
        /// </summary>
        /// <remarks>
        /// something weather related
        /// </remarks>
        /// <returns></returns>
        /// <response code = "400"> Empty data</response>
        /// <response code = "200">Returns list of weather report</response>
        [HttpGet()]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<WeatherForecast>> GetAllWeatherDetails()
        {
            _logger.LogInformation("Calling method : {0}", nameof(this.GetAllWeatherDetails));
            return await _weatherForcastService.GetWeatherForecastsAsync();
        }

        /// <summary>
        /// Get Weather Details
        /// </summary>
        /// <remarks>
        /// something weather related
        /// </remarks>
        /// <param name="Id">Id of City</param>
        /// <returns></returns>
        /// <response code = "400">Empty data</response>
        /// <response code = "200">Returns of weather report</response>
        [HttpGet()]
        [Route("GetWeatherById/{Id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(WeatherForecast), StatusCodes.Status200OK)]
        public async Task<WeatherForecast> GetWeatherById(int Id)
        {
            _logger.LogInformation("Calling method : {0}", nameof(this.GetWeatherById));
            return await _weatherForcastService.GetForcastAsync(Id);
        }
    }
}