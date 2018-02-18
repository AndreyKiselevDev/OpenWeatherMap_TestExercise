using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastApp.Models
{
    public class WeatherForecast
    {
        public WeatherForecast(string json)
        {
            Forecast = new List<WeatherForecastModel>();

            JObject jObject = JObject.Parse(json);
            JToken array = jObject["list"];

            for (int i = 0; i < array.Count(); i++)
            {
                var item = new WeatherForecastModel(JsonConvert.SerializeObject(array[i]));

                Forecast.Add(item);
            }   

        }

        public List<WeatherForecastModel> Forecast { get; set; }
    }
}
