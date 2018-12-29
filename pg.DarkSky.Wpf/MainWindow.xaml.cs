using pg.DarkSky.Wpf.Helpers;
using pg.DarkSky.Wpf.Models;
using pg.DarkSky.Wpf.Properties;
using pg.DarkSky.Wpf.ViewModels;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;

namespace pg.DarkSky.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {
            FlyAbout.IsOpen = !FlyAbout.IsOpen;
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            FlySettings.IsOpen = !FlySettings.IsOpen;
        }

        private void BtnDarkSky_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://darksky.net/poweredby/");
        }

        private void BtnMahapps_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://mahapps.com/");
        }

        private void BtnFeather_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://feathericons.com/");
        }

        private void BtnWeather_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://erikflowers.github.io/weather-icons/");
        }
    }
}
