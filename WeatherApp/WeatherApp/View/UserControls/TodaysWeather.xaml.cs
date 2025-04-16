using System;
using System.Collections.Generic;
using System.Linq;
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
using static WeatherApp.WeatherModel;

namespace WeatherApp.View.UserControls
{
    /// <summary>
    /// Interaction logic for TodaysWeather.xaml
    /// </summary>
    public partial class TodaysWeather : UserControl
    {
        public TodaysWeather()
        {
            InitializeComponent();
            infoControl.RequestedDate = DateTime.Today;
            infoControl.LoadStrategy = LoadTodayWeatherAsync;
        }
        private async Task<(string, string, string)> LoadTodayWeatherAsync(InfoTexts control)
        {
            var weatherService = new WeaherDataCalls();
            var weather = await weatherService.GetWeatherAsync(control.Latitude, control.Longitude);

            if (weather != null)
            {
                double fahrenheit = (weather.main.temp * 9 / 5) + 32;
                tbCurrentTemp.Text = fahrenheit.ToString();
                return ($"Temp: {fahrenheit:F1}°F", $"Wind: {weather.wind.speed} m/s", $"");
            }

            return ("Temp: Error", "Wind: Error", "");
        }
    }
}
