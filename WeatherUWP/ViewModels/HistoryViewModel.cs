using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherUWP.Models;
using WeatherUWP.Services;

namespace WeatherUWP.ViewModels
{
    public class HistoryViewModel
    {
        public List<HistoryModel> history { get; set; }
        public HistoryViewModel()
        {
            var service = new HistoryService();
            history = service.Get().ToList();
            history.Reverse();
        }
    }
}
