using ResidentWeather.Models;

namespace ResidentWeather.Services
{
    public class WeatherWidget
    {
        private Forecast _weather;

        private Widget widget;

        public WeatherWidget(Forecast weather)
        {
            _weather = weather;
            this.widget = new Widget();
        }

        public Widget SmallWidget()
        {
            widget.temperature = GetWidgetTemperature();

            return widget;
        }

        public Widget MediumWidget()
        {
            widget.temperature = GetWidgetTemperature();
            widget.icon = GetWidgetIcon();

            return widget;
        }

        public Widget BigWidget()
        {
            widget.temperature = GetWidgetTemperature();
            widget.name = _weather.name;
            widget.country = _weather.sys.country;
            widget.main = _weather.weather[0].main;
            widget.description = _weather.weather[0].description;
            widget.icon = GetWidgetIcon();
            widget.feelslike = (int)_weather.main.feels_like;
            widget.windspeed = _weather.wind.speed;
            widget.humidity = _weather.main.humidity;

            return widget;
        }

        public string GetWidgetTemperature()
        {
            string str = ((int)_weather.main.temp).ToString();
            
            return string.Format($"{str}\u00B0C");
        }

        public string GetWidgetIcon()
        {
            if (_weather.weather[0].id >= 200 && _weather.weather[0].id <= 232)
            {
                return $"http://openweathermap.org/img/wn/{_weather.weather[0].icon}@2x.png";
            }
            else if (_weather.weather[0].id >= 300 && _weather.weather[0].id <= 321)
            {
                return $"http://openweathermap.org/img/wn/{_weather.weather[0].icon}@2x.png";
            }
            else if (_weather.weather[0].id >= 500 && _weather.weather[0].id <= 504)
            {
                return $"http://openweathermap.org/img/wn/{_weather.weather[0].icon}@2x.png";
            }
            else if (_weather.weather[0].id == 511)
            {
                return $"http://openweathermap.org/img/wn/{_weather.weather[0].icon}@2x.png";
            }
            else if (_weather.weather[0].id >= 520 && _weather.weather[0].id <= 531)
            {
                return $"http://openweathermap.org/img/wn/{_weather.weather[0].icon}@2x.png";
            }
            else if (_weather.weather[0].id >= 600 && _weather.weather[0].id <= 622)
            {
                return $"http://openweathermap.org/img/wn/{_weather.weather[0].icon}@2x.png";
            }
            else if (_weather.weather[0].id >= 701 && _weather.weather[0].id <= 781)
            {
                return $"http://openweathermap.org/img/wn/{_weather.weather[0].icon}@2x.png";
            }
            else if (_weather.weather[0].id == 800)
            {
                return $"http://openweathermap.org/img/wn/{_weather.weather[0].icon}@2x.png";
            }
            else if (_weather.weather[0].id == 801)
            {
                return $"http://openweathermap.org/img/wn/{_weather.weather[0].icon}@2x.png";
            }
            else if (_weather.weather[0].id == 802)
            {
                return $"http://openweathermap.org/img/wn/{_weather.weather[0].icon}@2x.png";
            }
            else if (_weather.weather[0].id == 803 || _weather.weather[0].id == 804)
            {
                return $"http://openweathermap.org/img/wn/{_weather.weather[0].icon}@2x.png";
            }
            else 
            {
                return $"http://openweathermap.org/img/wn/{_weather.weather[0].icon}@2x.png";
            }
        }
    }
}