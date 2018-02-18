using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherForecastApp.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace WeatherForecastApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Weather()
        {
            return View();
        }

        public async Task<string> GetWeatherForecast(string city)
        {
            var forecast = await GetWeatherJSON("forecast", city);

            if (string.IsNullOrEmpty(forecast))
                return string.Empty;

            return JsonConvert.SerializeObject(new WeatherForecast(forecast));
        }
        public async Task<string> GetCurrentWeather(string city)
        {
            var weather = await GetWeatherJSON("weather", city);

            if (!string.IsNullOrEmpty(weather))
                return string.Empty;

            return JsonConvert.SerializeObject(new CurrentWeatherModel(weather));
        }

        private async Task<string> GetWeatherJSON(string type, string city)
        {
            string uri = $"http://api.openweathermap.org/data/2.5/{type}?q={city}&appid=4b34db0e258563245de0651f9636662a";

            var client = new HttpClient();

            try
            {
                return await client.GetStringAsync(uri);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
