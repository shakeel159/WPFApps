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

namespace WeatherApp.View.UserControls
{
    /// <summary>
    /// Interaction logic for MenuBar.xaml
    /// </summary>
    public partial class MenuBar : UserControl
    {
        public MenuBar()
        {
            InitializeComponent();
        }
        private void StateSelectedChange(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = StateSelected.SelectedItem as ComboBoxItem;
            if(selectedItem != null)
            {
                //inisitate change of information on weather app based on state selected
                string state = selectedItem.Content.ToString();
                MessageBox.Show($"You selected: {state}");
            }
        }
    }
}
