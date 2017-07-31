using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WeatherUWP.Models;
using WeatherUWP.Services;

namespace WeatherUWP.ViewModels
{
    public class CitiesViewModel: ViewModelBase
    {
        public ObservableCollection<CityModel> Cities { get; private set; }
        CityService service = new CityService();
        public ICommand AddCommand { get; set; }
        public string nameToAdd { get; set; }
        public CitiesViewModel()
        {
            var list=service.GetSelected();
            Cities = new ObservableCollection<CityModel>();
            foreach(var x in list)
            {
                Cities.Add(x);
            }
            AddCommand = new RelayCommand(AddCity);
           
        }

        void AddCity()
        {
            try
            {
                service.Add(nameToAdd);
                RaisePropertyChanged(() => Cities);
            }
            catch(Exception ex)
            {

            }
        }
        

    }
}
