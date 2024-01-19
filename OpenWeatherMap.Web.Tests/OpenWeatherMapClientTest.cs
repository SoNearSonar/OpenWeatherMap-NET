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
            var owmClient = new OpenWeatherMapClient(_apiKey);

            var data = owmClient.GetWeatherData(36.16, 139.11).Result;

            Assert.IsNotNull(data);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(data.Timezone));
            Assert.IsNotNull(data.Current);
            Assert.IsTrue(data.Current.UVIndex >= 0.0);
            Assert.IsTrue(data.Current.CloudCoverage >= 0);
            Assert.IsTrue(data.Minutely.Count >= 0);
            Assert.IsTrue(data.Hourly.Count > 0);
            Assert.IsTrue(data.Daily.Count > 0);
            Assert.IsTrue(data.Latitude == 36.16);
            Assert.IsTrue(data.Longitude == 139.11);
        }

        [TestMethod]
        public void TestGetWeatherData_ValidApiKey_AddedSettings_ReturnsWeatherData()
        {
            var owmClient = new OpenWeatherMapClient(_apiKey);
            var excludedData = new ExcludeData[] { ExcludeData.Minutely, ExcludeData.Hourly, ExcludeData.Alerts };

            var data = owmClient.GetWeatherData(36.16, 139.11, excludedData, UnitsOfMeasurement.Metric).Result;

            Assert.IsNotNull(data);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(data.Timezone));
            Assert.IsNotNull(data.Current);
            Assert.IsTrue(data.Current.UVIndex >= 0.0);
            Assert.IsNull(data.Minutely);
            Assert.IsNull(data.Hourly);
            Assert.IsNull(data.Alerts);
            Assert.IsTrue(data.Daily.Count > 0);
            Assert.IsTrue(data.Latitude == 36.16);
            Assert.IsTrue(data.Longitude == 139.11);
        }

        [TestMethod]
        public void TestGetWeatherData_InvlidApiKey_ReturnsError()
        {
            var owmClient = new OpenWeatherMapClient("");

            try
            {
                var data = owmClient.GetWeatherData(36.16, 139.11).Result;
                Assert.Fail("Test case should not go here");
            }
            catch (AggregateException agEx)
            {
                Assert.IsInstanceOfType(agEx.InnerException, typeof(HttpRequestException));
            }     
        }

        [TestMethod]
        public void TestGetDailyAggregateData_ValidApiKey_MinimalSettings_ReturnsDailyAggregateData()
        {
            var owmClient = new OpenWeatherMapClient(_apiKey);

            var data = owmClient.GetDailyAggregateData(36.16, 139.11, DateTime.Now).Result;

            Assert.IsNotNull(data);
            Assert.IsNotNull(data.Humidity);
            Assert.IsTrue(data.Humidity.Afternoon >= 0.0);
            Assert.IsNotNull(data.Temperature);
            Assert.IsTrue(data.Temperature.Morning >= 0.0);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(data.Timezone));
            Assert.IsTrue(data.Latitude == 36.16);
            Assert.IsTrue(data.Longitude == 139.11);
        }

        [TestMethod]
        public void TestGetDailyAggregateData_ValidApiKey_AddedSettings_ReturnsDailyAggregateData()
        {
            var owmClient = new OpenWeatherMapClient(_apiKey);

            var data = owmClient.GetDailyAggregateData(36.16, 139.11, DateTime.Now, "+02:00", UnitsOfMeasurement.Metric, DataLanguage.Japanese).Result;

            Assert.IsNotNull(data);
            Assert.IsNotNull(data.Humidity);
            Assert.IsTrue(data.Humidity.Afternoon >= 0.0);
            Assert.IsNotNull(data.Temperature);
            Assert.IsTrue(data.Temperature.Morning >= 0.0);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(data.Timezone));
            Assert.IsTrue(data.Latitude == 36.16);
            Assert.IsTrue(data.Longitude == 139.11);
        }

        [TestMethod]
        public void TestGetDailyAggregateData_InvlidApiKey_ReturnsError()
        {
            var owmClient = new OpenWeatherMapClient("");

            try
            {
                var data = owmClient.GetDailyAggregateData(36.16, 139.11, DateTime.Now).Result;
                Assert.Fail("Test case should not go here");
            }
            catch (AggregateException agEx)
            {
                Assert.IsInstanceOfType(agEx.InnerException, typeof(HttpRequestException));
            }
        }

        [TestMethod]
        public void TestGetWeatherDataForDate_ValidApiKey_MinimalSettings_ReturnsWeatherData()
        {
            var owmClient = new OpenWeatherMapClient(_apiKey);

            var data = owmClient.GetWeatherDataForDate(36.16, 139.11, DateTime.Now).Result;

            Assert.IsNotNull(data);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(data.Timezone));
            Assert.IsNotNull(data.Current);
            Assert.IsTrue(data.Current[0].UVIndex >= 0.0);
            Assert.IsTrue(data.Current[0].CloudCoverage >= 0);
            Assert.IsTrue(data.Latitude == 36.16);
            Assert.IsTrue(data.Longitude == 139.11);
        }

        [TestMethod]
        public void TestGetWeatherDataForDate_ValidApiKey_AddedSettings_ReturnsWeatherData()
        {
            var owmClient = new OpenWeatherMapClient(_apiKey);

            var data = owmClient.GetWeatherDataForDate(36.16, 139.11, DateTime.Now, UnitsOfMeasurement.Metric, DataLanguage.Japanese).Result;

            Assert.IsNotNull(data);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(data.Timezone));
            Assert.IsNotNull(data.Current);
            Assert.IsTrue(data.Current[0].UVIndex >= 0.0);
            Assert.IsTrue(data.Current[0].CloudCoverage >= 0);
            Assert.IsTrue(data.Latitude == 36.16);
            Assert.IsTrue(data.Longitude == 139.11);
        }

        [TestMethod]
        public void TestGetWeatherDataForDate_InvlidApiKey_ReturnsError()
        {
            var owmClient = new OpenWeatherMapClient("");

            try
            {
                var data = owmClient.GetWeatherDataForDate(36.16, 139.11, DateTime.Now).Result;
                Assert.Fail("Test case should not go here");
            }
            catch (AggregateException agEx)
            {
                Assert.IsInstanceOfType(agEx.InnerException, typeof(HttpRequestException));
            }
        }

        [TestMethod]
        public void TestGetCurrentAirPollutionData_ReturnsAirPollutionData()
        {
            var ownClient = new OpenWeatherMapClient(_apiKey);

            var data = ownClient.GetCurrentAirPollutionData(36.16, 139.11).Result;

            Assert.IsNotNull(data);
            Assert.IsNotNull(data.Coordinates);
            Assert.IsNotNull(data.AirPollutionList);
            Assert.IsNotNull(data.AirPollutionList[0].PollutionInfo);
            Assert.IsNotNull(data.AirPollutionList[0].PollutionComponents);
            Assert.IsTrue(data.Coordinates.Latitude == 36.16);
            Assert.IsTrue(data.Coordinates.Longitude == 139.11);
            Assert.IsNotNull(data.AirPollutionList[0].PollutionComponents.Ozone >= 0.0);
        }

        [TestMethod]
        public void TestGetCurrentAirPollutionData_InvlidApiKey_ReturnsError()
        {
            var owmClient = new OpenWeatherMapClient("");

            try
            {
                var data = owmClient.GetCurrentAirPollutionData(36.16, 139.11).Result;
                Assert.Fail("Test case should not go here");
            }
            catch (AggregateException agEx)
            {
                Assert.IsInstanceOfType(agEx.InnerException, typeof(HttpRequestException));
            }
        }

        [TestMethod]
        public void TestGetForecastAirPollutionData_ReturnsAirPollutionData()
        {
            var ownClient = new OpenWeatherMapClient(_apiKey);

            var data = ownClient.GetForecastAirPollutionData(36.16, 139.11).Result;

            Assert.IsNotNull(data);
            Assert.IsNotNull(data.Coordinates);
            Assert.IsNotNull(data.AirPollutionList);
            Assert.IsNotNull(data.AirPollutionList[0].PollutionInfo);
            Assert.IsNotNull(data.AirPollutionList[0].PollutionComponents);
            Assert.IsTrue(data.Coordinates.Latitude == 36.16);
            Assert.IsTrue(data.Coordinates.Longitude == 139.11);
            Assert.IsNotNull(data.AirPollutionList[0].PollutionComponents.Ozone >= 0.0);
        }

        [TestMethod]
        public void TestGetForecastAirPollutionData_InvlidApiKey_ReturnsError()
        {
            var owmClient = new OpenWeatherMapClient("");

            try
            {
                var data = owmClient.GetForecastAirPollutionData(36.16, 139.11).Result;
                Assert.Fail("Test case should not go here");
            }
            catch (AggregateException agEx)
            {
                Assert.IsInstanceOfType(agEx.InnerException, typeof(HttpRequestException));
            }
        }

        [TestMethod]
        public void TestGetHistoricalAirPollutionData_ReturnsAirPollutionData()
        {
            var ownClient = new OpenWeatherMapClient(_apiKey);

            var data = ownClient.GetHistoricalAirPollutionData(36.16, 139.11, DateTime.Today, DateTime.Now).Result;

            Assert.IsNotNull(data);
            Assert.IsNotNull(data.Coordinates);
            Assert.IsNotNull(data.AirPollutionList);
            Assert.IsNotNull(data.AirPollutionList[0].PollutionInfo);
            Assert.IsNotNull(data.AirPollutionList[0].PollutionComponents);
            Assert.IsTrue(data.Coordinates.Latitude == 36.16);
            Assert.IsTrue(data.Coordinates.Longitude == 139.11);
            Assert.IsNotNull(data.AirPollutionList[0].PollutionComponents.Ozone >= 0.0);
        }

        [TestMethod]
        public void TestGetHistoricalAirPollutionData_InvlidApiKey_ReturnsError()
        {
            var owmClient = new OpenWeatherMapClient("");

            try
            {
                var data = owmClient.GetHistoricalAirPollutionData(36.16, 139.11, DateTime.Today, DateTime.Now).Result;
                Assert.Fail("Test case should not go here");
            }
            catch (AggregateException agEx)
            {
                Assert.IsInstanceOfType(agEx.InnerException, typeof(HttpRequestException));
            }
        }
    }
}