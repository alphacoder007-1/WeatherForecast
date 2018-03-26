using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ESDAssignment.Models;
using System.Threading.Tasks;

namespace ESDAssignment.API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class WeatherController : ApiController
    {
        //string wundergroundAPIKey = "a15b7b4d039d71a0";C
        string weatherAPI = "http://api.wunderground.com/api/a15b7b4d039d71a0/forecast10day/q/{{State}}/{{City}}.json";

        string geoLookupAPI = "http://api.wunderground.com/api/a15b7b4d039d71a0/geolookup/q/{{latti}},{{longi}}.json";

        public WeatherController()
        {
            //weatherAPI = weatherAPI.Replace("{{City}}","Fremont").Replace("{{State}}","CA");
            //geoLookupAPI = geoLookupAPI.Replace("{{long}}", "37.55672058179357").Replace("{{lat}}", "-121.9686638706541");
        }

        // GET api/<controller>
        //public async Task<VMForeCast> Get()
        //{
        //    HttpClient client = new HttpClient();
        //    //HttpResponseMessage response = client.GetAsync(weatherAPI).Result;

        //    VMForeCast model = new VMForeCast();

        //    HttpResponseMessage response = await client.GetAsync(weatherAPI);
        //    if (response.IsSuccessStatusCode)
        //    {

        //        model = await response.Content.ReadAsAsync<VMForeCast>();
        //    }
        //    return model;
        //}


        //GET api/<controller>/<action>?longi={longi}&latti={latti}
        public async Task<WeatherForecastModel> GetWeather(string latti, string longi)
        {
            string state = string.Empty;
            string city = string.Empty;
            HttpClient client = new HttpClient();
            GeolookupModel geoModel = new GeolookupModel();
            ForeCastModel forecastModel = new ForeCastModel();
            HttpResponseMessage geoLookupResponse;
            HttpResponseMessage forecastResponse;

            geoLookupAPI = geoLookupAPI.Replace("{{latti}}", latti).Replace("{{longi}}", longi);

            geoLookupResponse = client.GetAsync(geoLookupAPI).Result;

            if (geoLookupResponse.IsSuccessStatusCode)
            {
                geoModel = await geoLookupResponse.Content.ReadAsAsync<GeolookupModel>();

                state = geoModel.location.state;
                city = geoModel.location.city;

                weatherAPI = weatherAPI.Replace("{{City}}", city).Replace("{{State}}", state);

                forecastResponse = client.GetAsync(weatherAPI).Result;

                if (forecastResponse.IsSuccessStatusCode)
                {
                    forecastModel = await forecastResponse.Content.ReadAsAsync<ForeCastModel>();
                }
            }

            Forecast forecastWeathermodel = new Forecast();

            forecastWeathermodel = forecastModel.forecast;

            Simpleforecast simpleforecast = forecastWeathermodel.simpleforecast;

            List<Forecastday> forecastdayList = new List<Forecastday>();

            forecastdayList = simpleforecast.forecastday;

            List<WeatherModel> weatherList = new List<WeatherModel>();
            WeatherModel weathermodel = null;

            foreach (Forecastday forecast in forecastdayList)
            {
                weathermodel = new WeatherModel();               
                weathermodel.weekday = forecast.date.weekday;
                weathermodel.high = forecast.high.fahrenheit;
                weathermodel.low = forecast.low.fahrenheit;
                weathermodel.conditions = forecast.conditions;
                weathermodel.icon_url = forecast.icon_url;
                weatherList.Add(weathermodel);
            }

            WeatherForecastModel weatherForeCastModel = new WeatherForecastModel();
            weatherForeCastModel.weatherModel = weatherList;
            weatherForeCastModel.city.Name = city;
            weatherForeCastModel.city.State = state;

            return weatherForeCastModel;   
        }


        //GET api/<controller>/<action>?city={city}&state={state}
        public async Task<WeatherForecastModel> GetWeatherByCity(string city, string state)
        {
         
            HttpClient client = new HttpClient();
            GeolookupModel geoModel = new GeolookupModel();
            ForeCastModel forecastModel = new ForeCastModel();
            HttpResponseMessage forecastResponse;

            weatherAPI = weatherAPI.Replace("{{City}}", city).Replace("{{State}}", state);

            forecastResponse = client.GetAsync(weatherAPI).Result;

            if (forecastResponse.IsSuccessStatusCode)
            {
                forecastModel = await forecastResponse.Content.ReadAsAsync<ForeCastModel>();
            }

            Forecast forecastWeathermodel = new Forecast();

            forecastWeathermodel = forecastModel.forecast;

            Simpleforecast simpleforecast = forecastWeathermodel.simpleforecast;

            List<Forecastday> forecastdayList = new List<Forecastday>();

            forecastdayList = simpleforecast.forecastday;

            List<WeatherModel> weatherList = new List<WeatherModel>();
            WeatherModel weathermodel = null;

            foreach (Forecastday forecast in forecastdayList)
            {
                weathermodel = new WeatherModel();
                weathermodel.weekday = forecast.date.weekday;
                weathermodel.high = forecast.high.fahrenheit;
                weathermodel.low = forecast.low.fahrenheit;
                weathermodel.conditions = forecast.conditions;
                weathermodel.icon_url = forecast.icon_url;
                weatherList.Add(weathermodel);
            }

            WeatherForecastModel weatherForeCastModel = new WeatherForecastModel();
            weatherForeCastModel.weatherModel = weatherList;
            weatherForeCastModel.city.Name = city;
            weatherForeCastModel.city.State = state;

            return weatherForeCastModel;
        }



        // GET api/<controller>/5
        public string Get()
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}