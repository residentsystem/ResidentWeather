using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ResidentWeather.Services;

namespace ResidentWeather.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        public string PageTitle = "ResidentWeather - Forecast Error";

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;

        public string Error { get; set; }

        public string Message { get; set; }

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionHandlerPathFeature?.Error is WeatherUrlWebException)
            {
                Error = "Destination Unreachable.";
                Message = "Weather service cannot be reached due to an apparent client error. Please verify weather settings in configuration file.";
            }

            if (exceptionHandlerPathFeature?.Error is WeatherUrlException)
            {
                Error = "Service Unavailable.";
                Message = "Weather service cannot be reached due to an internal client error. API Call contain no value.";
            }
        }
    }
}
