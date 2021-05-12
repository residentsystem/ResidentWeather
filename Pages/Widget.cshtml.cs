using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ResidentWeather.Models;
using ResidentWeather.Configurations;
using ResidentWeather.Services;

namespace ResidentWeather.Pages
{
    public class WidgetModel : PageModel
    {
        public string PageTitle = "ResidentWeather - Forecast weather widget collection";

        private string cityid;

        private string apikey;

        private string apicall;

        // Injecting the configuration to access the settings in the configuration file. 
        private IOptionsSnapshot<WeatherSettings> _weathersettings;

        public Forecast Weather { get; set; }

        public Widget SmallWidget { get; set; }

        public Widget MediumWidget { get; set; }

        public Widget BigWidget { get; set; }

        private readonly ILogger<WidgetModel> _logger;

        public WidgetModel(ILogger<WidgetModel> logger, IOptionsSnapshot<WeatherSettings> weathersettings)
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

            // Use the properties as weather widgets
            WeatherWidget widget = new WeatherWidget(Weather);

            // Get the temperature with the celsius symbol for a small widget.
            SmallWidget = widget.SmallWidget();

            // Get the temperature and weather icon for a medium size widget.
            MediumWidget = widget.MediumWidget();

            // Get the city name, temperature, weather icon and weather details for a big widget.
            BigWidget = widget.BigWidget();
        }
    }
}
