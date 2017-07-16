using System.ComponentModel.DataAnnotations;

namespace WebWeather.Models
{
    public class SelectedCityViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="Enter a city please")]
        public string Name { get; set; }
    }
}