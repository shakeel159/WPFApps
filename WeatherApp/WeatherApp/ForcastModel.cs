using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class ForcastModel
    {
        public List<ForecastListItem> list { get; set; }
    }

    public class ForecastListItem
    {
        public MainInfo main { get; set; }
        public string dt_txt { get; set; }
    }

    public class MainInfo
    {
        public double temp { get; set; }
    }
}
