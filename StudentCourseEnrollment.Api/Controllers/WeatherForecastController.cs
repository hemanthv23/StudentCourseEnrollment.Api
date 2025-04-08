using Microsoft.AspNetCore.Mvc;

namespace StudentCourseEnrollment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static List<WeatherForecast> _forecasts = new List<WeatherForecast>();

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // GET method to retrieve all weather forecasts
        [HttpGet(Name = "GetWeatherForecasts")]
        public ActionResult<IEnumerable<WeatherForecast>> Get()
        {
            if (!_forecasts.Any())
            {
                // Create 5 default forecasts if the list is empty
                _forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToList();
            }
            return Ok(_forecasts);
        }

        // GET method to retrieve a specific weather forecast by ID
        [HttpGet("{id}", Name = "GetWeatherForecastById")]
        public ActionResult<WeatherForecast> Get(int id)
        {
            var forecast = _forecasts.FirstOrDefault(f => f.Id == id);
            if (forecast == null)
            {
                return NotFound();
            }
            return Ok(forecast);
        }

        // POST method to create a new weather forecast
        [HttpPost]
        public ActionResult<WeatherForecast> Post([FromBody] WeatherForecast forecast)
        {
            if (forecast == null)
            {
                return BadRequest("Forecast data is required.");
            }

            forecast.Id = _forecasts.Count + 1; // Simple ID generation logic
            _forecasts.Add(forecast);

            return CreatedAtRoute("GetWeatherForecastById", new { id = forecast.Id }, forecast);
        }

        // PUT method to update an existing weather forecast
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] WeatherForecast forecast)
        {
            var existingForecast = _forecasts.FirstOrDefault(f => f.Id == id);
            if (existingForecast == null)
            {
                return NotFound();
            }

            existingForecast.Date = forecast.Date;
            existingForecast.TemperatureC = forecast.TemperatureC;
            existingForecast.Summary = forecast.Summary;

            return NoContent(); // Successfully updated, no content to return
        }

        // DELETE method to remove a weather forecast
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var forecast = _forecasts.FirstOrDefault(f => f.Id == id);
            if (forecast == null)
            {
                return NotFound();
            }

            _forecasts.Remove(forecast);

            return NoContent(); // Successfully deleted, no content to return
        }
    }
}
