using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebWeather.Models
{
    public class HistoryViewModel
    {
        public string Date { get; set; }
        public string City { get; set; }
        public double DayTemp { get; set; }
        public string Icon { get; set; }
        public int NumOfDaysRequested { get; set; }
    }
}