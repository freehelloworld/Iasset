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
using System.IO;
using System.Text;

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

            result.Time = DateTime.Now;
            
            //get current weather from the url.
            string strHTML = "";
            using(WebClient weatherWebClient = new WebClient())
            {
                string url = "http://samples.openweathermap.org/data/2.5/weather?q=" + model.CityName + "&appid=b1b15e88fa797225412429c1c50c122a1";
                Stream myStream = weatherWebClient.OpenRead(url);
                StreamReader sr = new StreamReader(myStream, Encoding.Default);
                strHTML = sr.ReadToEnd();
            }
            
            //if getting data failed, return an empty object.
            if(strHTML.Contains("error"))
            {
                result.IsSuccess = false;
                return result;
            }
            
            //the response structure is to complicated, don't want to define C# model to parse it.
            //just parse the string and find out what we need.
            
            
            result.SkyConditions = strHTML.Split(new string[] { "main\":\"" }, StringSplitOptions.RemoveEmptyEntries)[1].Split('\"')[0];
            result.Temperature = strHTML.Split(new string[] { "temp\":" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(',')[0];
            result.Visibility = strHTML.Split(new string[] { "visibility\":" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(',')[0];
            result.Wind = strHTML.Split(new string[] { "speed\":" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(',')[0];
            result.DewPoint = strHTML.Split(new string[] { "main\":\"" }, StringSplitOptions.RemoveEmptyEntries)[1].Split('\"')[0];
            result.RelativeHumidity = strHTML.Split(new string[] { "humidity\":" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(',')[0];
            result.Pressure = strHTML.Split(new string[] { "pressure\":" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(',')[0];
            result.IsSuccess = true;
            return result;
        }

    }
}
