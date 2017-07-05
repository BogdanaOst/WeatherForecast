using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebWeather.Models
{
    public class Parametrs
    {
        public string city { get; set; }
        public int numOfDays { get; set; }
    }
}