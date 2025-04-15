using DotNetEnv;
using Newtonsoft.Json;
using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class WeaherDataCalls
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private string ApiKey = Environment.GetEnvironmentVariable("WEATHER_API_KEY");
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";

        public async Task<WeatherModel> GetWeatherAsync(double lat, double lon)
        {
            var url = $"{BaseUrl}?lat={lat}&lon={lon}&appid={ApiKey}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WeatherModel>(jsonResponse);
        }
    }
}
