using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastApp.Extentions;

namespace WeatherForecastApp.Models
{
    public class WeatherInformation
    {
        public WeatherInformation(string json)
        {
            var jObject = JObject.Parse(json);

            var weather = jObject["weather"];
            WeatherIcon = (string)weather[0]["icon"];
            WeatherStatus = (string) weather[0]["main"];

            var wind = jObject["wind"];
            WindSpeed = (int) wind["speed"];


            var temperature = jObject["main"];
            Temperature = WeatherExtentions.GetCelsium((double) temperature["temp"]);

        }

        public string WeatherIcon { get; set; }

        public string WeatherStatus { get; set; }

        public int WindSpeed { get; set; }
        
        public int Temperature { get; set; }

    }
}
