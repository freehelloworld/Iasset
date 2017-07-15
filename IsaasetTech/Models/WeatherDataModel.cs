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

        public int Wind { get; set; }

        public int Visibility { get; set; }

        public int SkyConditions { get; set; }

        public int Temperature { get; set; }

        public int DewPoint { get; set; }

        public int RelativeHumidity { get; set; }

        public int Pressure { get; set; }
    }
}