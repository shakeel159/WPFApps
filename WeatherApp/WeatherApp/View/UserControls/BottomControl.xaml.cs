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
using WeatherApp;

namespace WeatherApp.View.UserControls
{
    /// <summary>
    /// Interaction logic for BottomControl.xaml
    /// </summary>
    public partial class BottomControl : UserControl
    {
        public BottomControl()
        {
            InitializeComponent();
            infoControl_Today.RequestedDate = DateTime.Today;
            infoControl_Tomorrow.RequestedDate = DateTime.Today.AddDays(1);
            infoControl_DayAfter.RequestedDate = DateTime.Today.AddDays(2);

            infoControl_Today.LoadStrategy = control => LoadTodayWeatherAsync(control, 0);
            infoControl_Tomorrow.LoadStrategy = control => LoadTomorrowWeatherAsync(control, 1);
            infoControl_DayAfter.LoadStrategy = control => LoadTomorrowWeatherAsync(control, 2);
        }
        private async Task<(string, string, string)> LoadTodayWeatherAsync(InfoTexts control, int daysAhead)
        {
            var weatherService = new WeaherDataCalls();
            var tomorrow = DateTime.UtcNow.AddDays(daysAhead);
            var weather = await weatherService.GetWeatherAsync(control.Latitude, control.Longitude);
            var lowTemp = await weatherService.GetLowestTempForDateAsync(control.Latitude, control.Longitude, tomorrow);
            var highTemp = await weatherService.GetHighestTempForDateAsync(control.Latitude, control.Longitude, tomorrow);

            if (weather != null)
            {
                double fahrenheit = (weather.main.temp * 9 / 5) + 32;
                double fLow = (lowTemp.Value * 9 / 5) + 32;
                double fHigh = (highTemp.Value * 9 / 5) + 32;
                return ($"Temp: {fahrenheit:F1}°F", $"Low: {fLow}",$"High: {fHigh}");
            }

            return ("Temp: Error", "Low: Error", "High: Error");
        }

        private async Task<(string, string, string)> LoadTomorrowWeatherAsync(InfoTexts control, int daysAhead)
        {
            var weatherService = new WeaherDataCalls();
            var tomorrow = DateTime.UtcNow.AddDays(daysAhead);

            var avgTemp = await weatherService.GetAverageTempForDataAsync(control.Latitude, control.Longitude, tomorrow);
            var lowTemp = await weatherService.GetLowestTempForDateAsync(control.Latitude, control.Longitude, tomorrow);
            var highTemp = await weatherService.GetHighestTempForDateAsync(control.Latitude, control.Longitude, tomorrow);

            if (avgTemp.HasValue && lowTemp.HasValue)
            {
                double fahrenheit = (avgTemp.Value * 9 / 5) + 32;
                double fLow = (lowTemp.Value * 9 / 5) + 32;
                double fHigh = (highTemp.Value * 9 / 5) + 32;
                return ($"Temp: {fahrenheit:F1}°F", $"Low: {fLow:F1}°F", $"High: {fHigh:F1}°F");
            }

            return ("Temp: Error", "Low: Error", "High: Error");
        }
    }
}
