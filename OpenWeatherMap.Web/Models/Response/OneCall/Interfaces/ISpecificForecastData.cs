using System.Collections.Generic;

namespace OpenWeatherMap.Web.Models
{
    // Fields shared among specific forecast data types (current, hourly, and daily)
    public interface ISpecificForecastData
    {
        int Pressure { get; set; }
        int Humidity { get; set; }
        double DewPoint { get; set; }
        double UVIndex { get; set; }
        int CloudCoverage { get; set; }
        double WindSpeed { get; set; }
        int WindDegrees { get; set; }
        double WindGust { get; set; }
        List<Weather> Weather { get; set; }
    }
}
