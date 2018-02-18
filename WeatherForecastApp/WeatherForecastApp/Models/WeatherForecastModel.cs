using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastApp.Models
{
    public class WeatherForecastModel : WeatherInformation
    {
        public WeatherForecastModel(string json) : base(json)
        {
            JObject jObject = JObject.Parse(json);

            DateTime time = DateTime.Parse((string)jObject["dt_txt"]);

            Time = time.ToString("HH:mm");

            Date = time.ToString("dd/MM");
        }

        public string Time { get; set; }

        public string Date { get; set; }
    }
}
