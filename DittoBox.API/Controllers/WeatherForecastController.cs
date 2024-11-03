using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.Controllers
{
    // Indicates that this class is an API controller and enables API-specific behaviors.
    [ApiController]
    // Specifies the route template for the controller. "[controller]" is replaced with the controller's name.
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        // A static array containing various weather summary descriptions.
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        // Logger instance for logging information within the controller.
        private readonly ILogger<WeatherForecastController> _logger;
        // Constructor that accepts a logger via dependency injection.
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // Handles HTTP GET requests to the controller's route.
        // The "Name" parameter assigns a name to this specific route.
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            // Generates a sequence of 5 weather forecast objects.
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                // Sets the date to 'index' days from today.
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                // Assigns a random temperature between -20 and 55 degrees Celsius.
                TemperatureC = Random.Shared.Next(-20, 55),
                // Selects a random weather summary from the 'Summaries' array.
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            // Converts the sequence to an array.
            .ToArray();
        }
    }
}
