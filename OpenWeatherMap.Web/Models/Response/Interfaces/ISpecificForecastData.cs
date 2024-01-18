namespace OpenWeatherMap.Web.Models
{
    // Fields shared among specific forecast data types (current, hourly, and daily)
    public interface ISpecificForecastData
    {
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double DewPoint { get; set; }
        public double UVIndex { get; set; }
        public double Clouds { get; set; }
        public double WindSpeed { get; set; }
        public int WindDegrees { get; set; }
        public List<Weather> Weather { get; set; }
    }
}
