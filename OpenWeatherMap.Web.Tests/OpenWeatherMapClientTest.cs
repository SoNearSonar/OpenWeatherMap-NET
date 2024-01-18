using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenWeatherMap.Web.Tests
{
    [TestClass]
    public class OpenWeatherMapClientTest
    {
        private readonly string _apiKey = "";

        [TestMethod]
        public void TestGetWeatherData_ValidApiKey_MinimalSettings_ReturnsWeatherData()
        {
            OpenWeatherMapClient owmClient = new OpenWeatherMapClient(_apiKey);
            WeatherData data = owmClient.GetWeatherData(36.16, 139.11).Result;

            Assert.IsNotNull(data);
        }
    }
}