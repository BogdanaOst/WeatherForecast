using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebWeather.Models
{
    public class Parametrs
    {
        public string CityName { get; set; }
        public int NumOfDays { get; set; }
    }
}