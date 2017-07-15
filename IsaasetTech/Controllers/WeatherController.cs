using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IsaasetTech.net.webservicex.www;
using System.Xml;
using IsaasetTech.Models;
using System.Net.Http.Headers;

namespace IsaasetTech.Controllers
{
    [RoutePrefix("api/weather")]
    public class WeatherController : ApiController
    {
        GlobalWeather _service;

        //set up default service.
        public WeatherController():this(new GlobalWeather())
        {

        }
        //inject the service in contructor
        public WeatherController(GlobalWeather service)
        {
            _service = service;
        }

        /// <summary>
        /// get city names of given country name.
        /// </summary>
        /// <returns>city name list.</returns>
        [Route("cities")]
        [HttpPost]
        public IEnumerable<string> GetCitiesByCountryName(CountryModel model)
        {
            //call the web service
            string cities = _service.GetCitiesByCountry(model.Name);

            // use xml document to parse the result.
            XmlDocument document = new XmlDocument();
            document.LoadXml(cities);
            XmlNodeList cityList = document.SelectNodes("//City");

            List<string> result = new List<string>();

            foreach(XmlElement city in cityList)
            {
                result.Add(city.InnerText.ToString());
            }

            return result;
        }

        /// <summary>
        /// get weather condition by city name and country name
        /// but both web services do not work. 
        /// just generate some random value for display purpose.
        /// </summary>
        /// <returns>weather data</returns>
        [Route("display")]
        [HttpPost]
        public WeatherResult GetWeatherByCity(CityModel model)
        {
            //call the web service, but get no result.
            string data = _service.GetWeather(model.CityName, model.CountryName);

            WeatherResult result = new WeatherResult();

            Random rnd = new Random();

            //get some random value.
            result.Time = DateTime.Now;
            result.Wind = rnd.Next(1, 10);
            result.Visibility = rnd.Next(0, 1);
            result.SkyConditions = rnd.Next(1, 5);
            result.Temperature = rnd.Next(-10, 40);
            result.DewPoint = rnd.Next(10, 20);
            result.RelativeHumidity = rnd.Next(0, 10);
            result.Pressure = rnd.Next(50, 100);

            return result;
        }

    }
}
