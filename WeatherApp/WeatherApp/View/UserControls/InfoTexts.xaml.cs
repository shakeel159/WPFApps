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
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp.View.UserControls
{
    public partial class InfoTexts : UserControl
    {
        // A Func to dynamically control what kind of weather data to load
        public Func<InfoTexts, Task<(string tempText, string lowWingText, string highWindText)>> LoadStrategy { get; set; } 
        // Func<>(stores ref to function) ,
        // //Takes one argument: an InfoTexts object. Returns a Task<...> which means it's asynchronous
        //he control (InfoTexts) can be told:“Here’s how you should load your data when needed.”

        public static readonly DependencyProperty LatitudeProperty =
            DependencyProperty.Register("Latitude", typeof(double), typeof(InfoTexts),
                new PropertyMetadata(41.8781, OnLocationChanged));

        public static readonly DependencyProperty LongitudeProperty =
            DependencyProperty.Register("Longitude", typeof(double), typeof(InfoTexts),
                new PropertyMetadata(-87.6298, OnLocationChanged));

        public static readonly DependencyProperty RequestedDateProperty =
            DependencyProperty.Register("RequestedDate", typeof(DateTime), typeof(InfoTexts),
                new PropertyMetadata(DateTime.Today, OnLocationChanged));

        public double Latitude
        {
            get => (double)GetValue(LatitudeProperty);
            set => SetValue(LatitudeProperty, value);
        }

        public double Longitude
        {
            get => (double)GetValue(LongitudeProperty);
            set => SetValue(LongitudeProperty, value);
        }

        public DateTime RequestedDate
        {
            get => (DateTime)GetValue(RequestedDateProperty);
            set => SetValue(RequestedDateProperty, value);
        }

        public InfoTexts()
        {
            InitializeComponent();
            Loaded += InfoTexts_Loaded;
        }

        private void InfoTexts_Loaded(object sender, RoutedEventArgs e)
        {
            _ = LoadWeatherAsync();
        }

        private static void OnLocationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as InfoTexts;
            _ = control?.LoadWeatherAsync();  // Refresh if any property changes
        }
        private async Task LoadWeatherAsync()
        {
            try
            {
                tbDate.Text = RequestedDate.ToString("yyyy-MM-dd");

                if (LoadStrategy != null) // returns the 3 strings for this method to use
                {
                    var (temp, Low, High) = await LoadStrategy(this);
                    tbTemp.Text = temp;
                    tbLow.Text = Low;
                    tbHigh.Text = High;
                }
                else
                {
                    tbTemp.Text = "Temp: No strategy";
                    tbLow.Text = "Low: No strategy";
                    tbHigh.Text = "High: No strategy";
                }
            }
            catch
            {
                tbDate.Text = "Date: Error";
                tbTemp.Text = "Temp: Error";
                tbLow.Text = "Wind: Error";
                tbHigh.Text = "High: Error";
            }
        }
       
    }
}
