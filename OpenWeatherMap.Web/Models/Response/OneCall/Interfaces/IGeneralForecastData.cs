using System;

namespace OpenWeatherMap.Web.Models
{
    // Fields shared among all forecast data types (current, hourly, minutely, and daily)
    // Used to fix an edge case with minutely only having DateTime and Precipitation
    public interface IGeneralForecastData
    {
        public DateTime DateTime { get; set; }
    }
}
