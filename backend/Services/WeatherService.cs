using System.Net.Http;
using System.Text.Json;
using WeatherApp.Models;

namespace WeatherApp.Services{
    public class WeatherService{
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "API_KEY";

        public WeatherService(HttpClient httpClient){
            _httpClient = httpClient;
        }  
 
        public async Task<WeatherResponse> GetWeather(string city){
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}";
            var response = await _httpClient.GetStringAsync(url);
            var json = JsonDocument.Parse(response);
            var temp = json.RootElement.GetProperty("main").GetProperty("temp").GetDouble();
            return new WeatherResponse{
                Temperature=temp
            };
        }
    }
}


