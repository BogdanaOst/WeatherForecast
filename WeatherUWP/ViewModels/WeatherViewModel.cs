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
    public class WeatherViewModel : ViewModelBase
    {
        public WeatherModel _forecast { get; set; }
        public ICommand ForecastCommand { get; set; }

        public string city { get; set; }
        public int NumOfDays { get; set; }
        public ObservableCollection<string> Cities { get; private set; }

        public WeatherViewModel()
        {

            ForecastCommand = new RelayCommand(GetWeather);
            _forecast = new WeatherModel();
            Cities = new ObservableCollection<string>();
            UpdateCities();
            MessengerInstance.Register< Message<ObservableCollection < CityModel >>>(this, list => { UpdateCities(); });
        }

        public void UpdateCities()
        {
            var serv = new CityService();
            var cityList = serv.GetSelected();
            if (cityList != null)
            Cities.Clear();   
            foreach (var item in cityList.Result)
                Cities.Add(item.Name);
        }
           
    public async void GetWeather()
        {
            try
            {
                var service = new WeatherService();
                _forecast = await service.GetForesect(city, NumOfDays);
                RaisePropertyChanged(() => _forecast);
                MessengerInstance.Send(new Message<WeatherModel>());
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
