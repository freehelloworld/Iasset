using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IsaasetTech;
using IsaasetTech.Controllers;
using IsaasetTech.Models;

namespace IsaasetTech.Tests.Controllers
{
    [TestClass]
    public class WeatherControllerTest
    {
        /// <summary>
        /// Pass 'Australia' to the API
        /// Will get a list of cities
        /// </summary>
        [TestMethod]
        public void ShouldNotEqualToZero()
        {
            // Arrange
            WeatherController controller = new WeatherController();

            CountryModel model = new CountryModel
            {
                Name="Australia"
            };

            // Act
            IEnumerable<string> result = controller.GetCitiesByCountryName(model);
            Assert.AreNotEqual(result.Count(), 0);
        }


        /// <summary>
        /// Pass 'AFEC' to the API
        /// Will get an empty list.
        /// </summary>
        [TestMethod]
        public void ShouldEqualToZero()
        {
            // Arrange
            WeatherController controller = new WeatherController();

            CountryModel model = new CountryModel
            {
                Name = "AFEC"
            };

            // Act
            IEnumerable<string> result = controller.GetCitiesByCountryName(model);

            Assert.AreEqual(result.Count(), 0);
        }


        /// <summary>
        /// Pass 'Beijing', 'China' to the API
        /// Will get weather data.
        /// </summary>
        [TestMethod]
        public void ShouldGetWeatherData()
        {
            // Arrange
            WeatherController controller = new WeatherController();

            CityModel model = new CityModel
            {
                CityName = "BeiJing",
                CountryName = "China"
            };

            // Act
            WeatherResult result = controller.GetWeatherByCity(model);

            Assert.AreNotEqual(result, null);
        }

    }
}
