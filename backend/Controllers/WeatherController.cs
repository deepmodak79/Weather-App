using Microsoft.AspNetCore.Mvc;
using WeatherApp.Services;
using WeatherApp.Models;

namespace WeatherApp.Controllers{
    [ApiController]
    [Route("api/controller")]
    public class WeatherController : ControllerBase{
        private readonly WeatherService _weatherService;
        public WeatherController(WeatherService weatherService){
            _weatherService = weatherService;
        }
        [HttpGet]
        public async Task<IActionResult> GetWeather(string city){
            var result = await _weatherService.GetWeather(city);
            return Ok(result);
    }
    }
}