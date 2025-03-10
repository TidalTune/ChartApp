using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartApp
{
    class WeatherEvent
    {
        public int id { get; set; }
        public string day { get; set; }
        public int temp { get; set; }

        public override string ToString()
        {
            return $"{id} - {day} - {temp}";
        }
    }
}
