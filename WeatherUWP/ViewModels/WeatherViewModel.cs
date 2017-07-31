using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherUWP.Models;
using WeatherUWP.Services;

namespace WeatherUWP.ViewModels
{
    public class WeatherViewModel: ViewModelBase
    {
        public WeatherModel _forecast { get; set; }
        public ICommand ForecastCommand { get; set; }

        public string city { get; set; }
        public int NumOfDays { get; set; }
        public List<string> Cities { get; private set; }

        public WeatherViewModel()
        {
            
            ForecastCommand = new RelayCommand(GetWeather);
            _forecast = new WeatherModel();
            var serv = new CityService();
            var cityList = serv.GetSelected();
            
            if (cityList != null)
            {
                Cities = new List<string>();
                foreach (var item in cityList)
                    Cities.Add(item.Name);
            }
            
        }

        public async void GetWeather()
        {
            try
            {
                var service = new WeatherService();
                _forecast = await service.GetForesect(city, NumOfDays);
                RaisePropertyChanged(() => _forecast);
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
