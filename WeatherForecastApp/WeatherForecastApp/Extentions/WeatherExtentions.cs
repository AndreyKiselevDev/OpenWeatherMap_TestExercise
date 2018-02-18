using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastApp.Extentions
{
    public static class WeatherExtentions
    {
        public static int GetCelsium(double temperature)
        {
            return (int) (temperature - 273.15);
        }

    }
}
