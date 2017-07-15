using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsaasetTech.Models
{
    public class CountryModel
    {
        public string Name { get; set; }
   }

    public class CityModel
    {
        public string CountryName { get; set; }
        public string CityName { get; set; }
    }

    public class WeatherResult
    {
        public DateTime Time { get; set; }

        public string Wind { get; set; }

        public string Visibility { get; set; }

        public string SkyConditions { get; set; }

        public string Temperature { get; set; }

        public string DewPoint { get; set; }

        public string RelativeHumidity { get; set; }

        public string Pressure { get; set; }
    }

    public class CurrentWeather
    {
        public string Coord { get; set; }

        public string Sys { get; set; }

        public string Weather { get; set; }

        public string Base { get; set; }

        public string Main { get; set; }

        public string Wind { get; set; }

        public string Clouds { get; set; }

        public string Dt { get; set; }

        public string Name { get; set; }

        public string Cod { get; set; }
    }
}