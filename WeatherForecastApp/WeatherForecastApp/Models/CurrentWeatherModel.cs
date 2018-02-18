using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastApp.Extentions;

namespace WeatherForecastApp.Models
{
    public class CurrentWeatherModel : WeatherInformation
    {
        public CurrentWeatherModel(string json) : base(json)
        {
            var jObject = JObject.Parse(json);

            City = (string) jObject["name"];

            var sys = jObject["sys"];
            Country = (string) sys["country"];

            var temperature = jObject["main"];
            MinimalTemperature = WeatherExtentions.GetCelsium((double)temperature["temp_min"]);
            MaximalTemperature = WeatherExtentions.GetCelsium((double)temperature["temp_max"]);

        }


        public int MinimalTemperature { get; set; }

        public int MaximalTemperature { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
    }
}
