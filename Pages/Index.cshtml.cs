using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ResidentWeather.Models;
using ResidentWeather.Configurations;
using ResidentWeather.Services;

namespace ResidentWeather.Pages
{
    public class IndexModel : PageModel
    {
        public string PageTitle = "ResidentWeather - Forecast weather data collection";

        private string cityid;

        private string apikey;

        private string apicall;

        // Injecting the configuration to access the settings in the configuration file. 
        private IOptionsSnapshot<WeatherSettings> _weathersettings;

        public Forecast Weather { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IOptionsSnapshot<WeatherSettings> weathersettings)
        {
            _logger = logger;
            _weathersettings = weathersettings;
        }

        public void OnGet()
        {
            cityid = _weathersettings.Value.Id;
            apikey = _weathersettings.Value.Appid;

            apicall = $"https://api.openweathermap.org/data/2.5/weather?id={cityid}&units=metric&appid={apikey}";

            // Convert all weather properties as .NET objects.
            WeatherConverter converter = new WeatherConverter(apicall);
            Weather = converter.DeserializeJsonFile();
        }
    }
}
