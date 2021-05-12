using System;
using System.Net;

namespace ResidentWeather.Services
{
    public class WeatherUrlWebException : WebException
    {
        public WeatherUrlWebException(string message = "Could not retreive the API url. Verify that the location exist and try again.") : base (message)
        {

        }
    }
    public class WeatherUrlException : ArgumentException
    {
        public WeatherUrlException(string message = "Could not retreive the API url. Verify that the location exist and try again.") : base (message)
        {

        }
    }
}