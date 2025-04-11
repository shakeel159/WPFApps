using System.Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WeatherApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string formattedDate = DateTime.Today.ToString("yyyy-MM-dd");
            tbDate.Text = "Todays Date: " + formattedDate;
        }
    }
}