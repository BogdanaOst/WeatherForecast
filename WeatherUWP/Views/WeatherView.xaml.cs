using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace WeatherUWP.Views
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class WeatherView : Page
    {
        public WeatherView()
        {
            this.InitializeComponent();
            comboDays.ItemsSource = new List<int>() { 1, 3, 7 };
        }

        private void comboCities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboCities.SelectedItem != null)
            {
                textCity.Text = comboCities.SelectedItem.ToString();
            }
        }

      
    }
}
