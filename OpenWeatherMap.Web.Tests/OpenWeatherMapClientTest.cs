using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenWeatherMap.Web.Models;

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
            Assert.IsTrue(!string.IsNullOrWhiteSpace(data.Timezone));
            Assert.IsNotNull(data.Current);
            Assert.IsTrue(data.Current.UVIndex >= 0);
            Assert.IsTrue(data.Current.CloudCoverage >= 0);
            Assert.IsTrue(data.Minutely.Count > 0);
            Assert.IsTrue(data.Hourly.Count > 0);
            Assert.IsTrue(data.Daily.Count > 0);
            Assert.IsTrue(data.Latitude == 36.16);
            Assert.IsTrue(data.Longitude == 139.11);
        }

        [TestMethod]
        public void TestGetWeatherData_ValidApiKey_AddedSettings_ReturnsWeatherData()
        {
            OpenWeatherMapClient owmClient = new OpenWeatherMapClient(_apiKey);
            List<ExcludeData> excludedData = new List<ExcludeData>() { ExcludeData.Minutely, ExcludeData.Hourly };

            WeatherData data = owmClient.GetWeatherData(36.16, 139.11, excludedData, UnitsOfMeasurement.Metric).Result;

            Assert.IsNotNull(data);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(data.Timezone));
            Assert.IsNotNull(data.Current);
            Assert.IsTrue(data.Current.UVIndex >= 0);
            Assert.IsNull(data.Minutely);
            Assert.IsNull(data.Hourly);
            Assert.IsTrue(data.Daily.Count > 0);
            Assert.IsTrue(data.Latitude == 36.16);
            Assert.IsTrue(data.Longitude == 139.11);
        }

        [TestMethod]
        public void TestGetWeatherData_InvlidApiKey_ReturnsError()
        {
            OpenWeatherMapClient owmClient = new OpenWeatherMapClient("");

            try
            {
                WeatherData data = owmClient.GetWeatherData(36.16, 139.11).Result;
                Assert.Fail("Test case should not go here");
            }
            catch (AggregateException agEx)
            {
                Assert.IsInstanceOfType(agEx.InnerException, typeof(HttpRequestException));
            }     
        }
    }
}