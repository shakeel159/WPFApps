using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;

namespace WeatherApp
{
    public static class ApiHelper
    {
        public static HttpClient weatherAPI { get; set; }

        public static void InitializeClient()
        {
            Env.Load();
            weatherAPI = new HttpClient();
            weatherAPI.DefaultRequestHeaders.Accept.Clear();
            weatherAPI.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Log the API key loading part
            string apiKey = Environment.GetEnvironmentVariable("WEATHER_API_KEY");
            Console.WriteLine($"Using API Key: {apiKey}");
        }
    }
}
