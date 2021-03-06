﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WeatherUWP.Views;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace WeatherUWP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Frame.Navigate(typeof(WeatherView));
        }
       

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WeatherView));
            
        }

        private void Cities_Click(object sender, RoutedEventArgs e)
        {

            Frame.Navigate(typeof(CitiesView));
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HistoryView));
        }
    }
}
