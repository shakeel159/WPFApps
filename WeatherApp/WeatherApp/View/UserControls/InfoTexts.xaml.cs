using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp.View.UserControls
{
    /// <summary>
    /// Interaction logic for InfoTexts.xaml
    /// </summary>
    public partial class InfoTexts : UserControl
    {
        public InfoTexts()
        {
            InitializeComponent();
            string formattedDate = DateTime.Today.ToString("yyyy-MM-dd");
            tbDate.Text = "" + formattedDate;

            // Start async weather fetch
            _ = LoadWeatherAsync();

        }
        private async Task LoadWeatherAsync()
        {
            try
            {
                var weatherService = new WeaherDataCalls();
                // Example coordinates: Chicago
                double lat = 41.8781;
                double lon = -87.6298;

                var weather = await weatherService.GetWeatherAsync(lat, lon);
                if (weather != null)
                {
                    tbTemp.Text = $"Temp: {weather.main.temp}°C";
                    tbWind.Text = $"Wind: {weather.wind.speed} m/s";
                }

            }
            catch (Exception ex)
            {
                tbTemp.Text = "Temp: Error";
                tbWind.Text = "Wind: Error";
                Console.WriteLine("Error fetching weather: " + ex.Message);
            }
        }
    }
}
