using DotNetEnv;
using System.Configuration;
using System.Data;
using System.Windows;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Load the .env file
            Env.Load();

            string apiKey = Env.GetString("WEATHER_API_KEY");

            // Use the API key as needed
            Console.WriteLine($"Loaded API Key: {apiKey}");
        }
    }

}
