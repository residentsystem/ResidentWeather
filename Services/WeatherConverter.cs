using System;
using System.Net;
using System.Text.Json;
using ResidentWeather.Models;

namespace ResidentWeather.Services
{
    public class WeatherConverter
    {
        string _apicall;

        private Forecast weather = new Forecast();

        private WebClient client = new WebClient();

        public Forecast Weather { get; set; }

        public WeatherConverter(string apicall)
        {
            _apicall = apicall;
        }

        public Forecast DeserializeJsonFile()
        {
            try 
            {
                // The resource to download is specified as a string containing the URI.
                string jsonstring = client.DownloadString(_apicall);

                // Parses the text representing a single JSON value into an instance of object type Forecast. 
                Weather = JsonSerializer.Deserialize<Forecast>(jsonstring);
            }
            catch (WebException)
            {
                throw new WeatherUrlWebException();
            }
            catch (ArgumentException)
            {
                throw new WeatherUrlException();
            }

            return Weather;
        }
    }
}