using WeatherUWP.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace WeatherUWP
{
    public class ViewModelLocator
    {
        public WeatherViewModel WeatherVMInstance => ServiceLocator.Current.GetInstance<WeatherViewModel>();

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            NavigationService navigationService = new NavigationService();
            navigationService.Configure(nameof(WeatherViewModel), typeof(WeatherViewModel));

            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            SimpleIoc.Default.Register<WeatherViewModel>();
        }
    }
}