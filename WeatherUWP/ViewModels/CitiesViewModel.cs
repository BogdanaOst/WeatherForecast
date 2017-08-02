using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherUWP.Models;
using WeatherUWP.Services;

namespace WeatherUWP.ViewModels
{
    public class CitiesViewModel : ViewModelBase
    {
        private ObservableCollection<CityModel> _cities;
        public ObservableCollection<CityModel> Cities
        {
            get { return _cities; }
            set
            {
                _cities = value;
                RaisePropertyChanged("Cities");
            }
        }
        CityService service = new CityService();

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public string nameToAdd { get; set; }
        public CityModel nameToDelete { get; set; }
        public CitiesViewModel()
        {

            Cities = new ObservableCollection<CityModel>();
            Update();
            AddCommand = new RelayCommand(AddCity);
            DeleteCommand = new RelayCommand(async()=>await DeleteCity());

            void Update()
            {

                var list = service.GetSelected().Result;
                Cities.Clear();
                foreach (var x in list)
                {
                    Cities.Add(x);
                }
                MessengerInstance.Send(new Message<ObservableCollection<CityModel>>());
            }
            void AddCity()
            {
                try
                {
                    service.Add(nameToAdd);
                    Update();
                }
                catch (Exception ex)
                {

                }
            }

            async Task DeleteCity()
            {
                try
                {
                    await service.Delete(nameToDelete.Name);
                    Update();
                }
                catch (Exception ex)
                {

                }
            }



        }
    }
}