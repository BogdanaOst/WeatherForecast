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
        public ICommand DeleteCommand { get; set; }
        public string nameToAdd { get; set; }
        public string nameToDelete { get; set; }
        public CitiesViewModel()
        {

            Cities = new ObservableCollection<CityModel>();
            Update();
            AddCommand = new RelayCommand(AddCity);
            DeleteCommand = new RelayCommand(DeleteCity);
        }

        void Update()
        {
            Cities.Clear();
            var list = service.GetSelected();
            foreach (var x in list)
            {
                Cities.Add(x);
            }
        }
        void AddCity()
        {
            try
            {
                service.Add(nameToAdd);
                Update();
            }
            catch(Exception ex)
            {

            }
        }

        void DeleteCity()
        {
            try
            {
                
                service.Delete(nameToDelete);
                Update();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
