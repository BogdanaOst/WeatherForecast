
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Linq;
using WeatherUWP.Models;
using WeatherUWP.Services;
namespace WeatherUWP.ViewModels
{
    public class HistoryViewModel : ViewModelBase
    {
        public ObservableCollection<HistoryModel> history { get; private set; }
        public HistoryViewModel()
        {
            history = new ObservableCollection<HistoryModel>();
            Update();
            MessengerInstance.Register<Message<WeatherModel>>(this, list => { Update(); });
        }

        public void Update()
        {
            var service = new HistoryService();
            var list = service.Get().Result;
            list.Reverse();
            history.Clear();
            foreach (var x in list)
                history.Add(x);
        }
    }
}
