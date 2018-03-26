using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using ESDAssignment.Models;

namespace ESDAssignement.API.Tests
{
    /// <summary>
    /// Summary description for WeatherControllerUnitTest
    /// </summary>
    [TestClass]
    public class WeatherControllerUnitTest
    {
        public WeatherControllerUnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            //string latti = "37.774929";
            //string longi = "-122.419416";

            //string state = string.Empty;
            //string city = string.Empty;
            //HttpClient client = new HttpClient();
            //GeolookupModel geoModel = new GeolookupModel();
            //ForeCastModel forecastModel = new ForeCastModel();
            //HttpResponseMessage geoLookupResponse;
            //HttpResponseMessage forecastResponse;

            //geoLookupAPI = geoLookupAPI.Replace("{{latti}}", latti).Replace("{{longi}}", longi);

            //geoLookupResponse = client.GetAsync(geoLookupAPI).Result;

            //if (geoLookupResponse.IsSuccessStatusCode)
            //{
            //    geoModel = await geoLookupResponse.Content.ReadAsAsync<GeolookupModel>();

            //    state = geoModel.location.state;
            //    city = geoModel.location.city;

            //    weatherAPI = weatherAPI.Replace("{{City}}", city).Replace("{{State}}", state);

            //    forecastResponse = client.GetAsync(weatherAPI).Result;

            //    if (forecastResponse.IsSuccessStatusCode)
            //    {
            //        forecastModel = await forecastResponse.Content.ReadAsAsync<ForeCastModel>();
            //    }
            //}

            //Forecast forecastWeathermodel = new Forecast();

            //forecastWeathermodel = forecastModel.forecast;

            //Simpleforecast simpleforecast = forecastWeathermodel.simpleforecast;

            //List<Forecastday> forecastdayList = new List<Forecastday>();

            //forecastdayList = simpleforecast.forecastday;

            //List<WeatherModel> weatherList = new List<WeatherModel>();
            //WeatherModel weathermodel = null;

            //foreach (Forecastday forecast in forecastdayList)
            //{
            //    weathermodel = new WeatherModel();
            //    weathermodel.weekday = forecast.date.weekday;
            //    weathermodel.high = forecast.high.fahrenheit;
            //    weathermodel.low = forecast.low.fahrenheit;
            //    weathermodel.conditions = forecast.conditions;
            //    weathermodel.icon_url = forecast.icon_url;
            //    weatherList.Add(weathermodel);
            //}

            //WeatherForecastModel weatherForeCastModel = new WeatherForecastModel();
            //weatherForeCastModel.weatherModel = weatherList;
            //weatherForeCastModel.city.Name = city;
            //weatherForeCastModel.city.State = state;

            //return weatherForeCastModel;
        }
    }
}
