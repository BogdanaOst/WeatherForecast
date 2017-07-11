using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebWeather.Models
{
    public class SelectedCityViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="Enter a city please")]
        public string Name { get; set; }
    }
}