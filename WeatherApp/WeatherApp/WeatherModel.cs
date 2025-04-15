using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class WeatherModel
    {
        public Main main { get; set; }
        public Wind wind { get; set; }

        public class Main
        {
            public double temp { get; set; }
        }

        public class Wind
        {
            public double speed { get; set; }

        }
    }

}
