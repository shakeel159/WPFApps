using DotNetEnv;
using Newtonsoft.Json;
using Sprache;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
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
        private const string ForecastUrl = "https://api.openweathermap.org/data/2.5/forecast"; //Forcast endpoint allows future temputrures in 3 hour intervals for up to 5 days

        public async Task<WeatherModel> GetWeatherAsync(double lat, double lon)
        {
            var url = $"{BaseUrl}?lat={lat}&lon={lon}&appid={ApiKey}&units=metric";
            var response = await _httpClient.GetAsync(url);//Sends the HTTP GET request to the OpenWeatherMap server.
            response.EnsureSuccessStatusCode();//Makes sure the server responded with a success (200 OK). If not, it throws an exception.
            var jsonResponse = await response.Content.ReadAsStringAsync();//Reads the JSON body of the response as a string.
            return JsonConvert.DeserializeObject<WeatherModel>(jsonResponse);//Converts the JSON string into a WeatherModel object, so you can access .main.temp, .wind.speed, etc.
        }

        // Gets raw forecast data
        public async Task<ForcastModel> GetForcastModelAsync(double lat, double lon)
        {
            var url = $"{ForecastUrl}?lat={lat}&lon={lon}&appid={ApiKey}&units=metric";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ForcastModel>(jsonResponse);
        }
        // Gets average temperature for a specific date
        public async Task<double?> GetAverageTempForDataAsync(double lat, double lon, DateTime date)
        {
            var forecast = await GetForcastModelAsync(lat, lon);

            var tempsForDate = forecast.list
            .Where(item => DateTime.Parse(item.dt_txt).Date == date.Date)
            .Select(item => item.main.temp)
            .ToList();

            if (!tempsForDate.Any())
                return null;

            return tempsForDate.Average();
        }
        public async Task<double?> GetLowestTempForDateAsync(double lat, double lon, DateTime date)
        {
            var forecast = await GetForcastModelAsync(lat, lon); // custom method that returns a deserialized forecast model

            var targetDate = date.Date;

            var tempsOnDate = forecast.list
                .Where(item => DateTime.Parse(item.dt_txt).Date == targetDate)
                .Select(item => item.main.temp) // or .temp if temp_min not available
                .ToList();

            if (tempsOnDate.Count > 0)
            {
                return tempsOnDate.Min();
            }

            return null;
        }
        public async Task<double?> GetHighestTempForDateAsync(double lat, double lon, DateTime date)
        {
            var forcast = await GetForcastModelAsync(lat,lon);

            var targetDate = date.Date; 
            var tempsForDate = forcast.list
                .Where(item => DateTime.Parse(item.dt_txt).Date == targetDate)
                .Select(item => item.main.temp) // or .temp if temp_min not available
                .ToList();
            if (tempsForDate.Count > 0)
            {
                return tempsForDate.Max();
            }

            return null;
        }
    }
}
