using pg.DarkSky.Wpf.Properties;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace pg.DarkSky.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //ha a verziószámok változnának, akkor ez segít a korábbi beállításokat áthozni a legújabb properties állományba
            Settings.Default.Upgrade();

            //Ez a felület nyelve miatt kell
            CultureInfo.DefaultThreadCurrentCulture =
                                CultureInfo.CreateSpecificCulture(Settings.Default.Culture);
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.DefaultThreadCurrentCulture;

            //ez pedig a nyelvi beállítások miatt (dátum, idő, számok)
            Thread.CurrentThread.CurrentCulture = CultureInfo.DefaultThreadCurrentCulture;

            var culture = CultureInfo.DefaultThreadCurrentCulture;
            var dict = new ResourceDictionary
            {
                Source = new Uri($"pack://application:,,,/Resources/StringResources.{culture.Name}.xaml")
            };
            Application.Current.Resources
                               .MergedDictionaries
                               .Add(dict);

            base.OnStartup(e);
        }
    }
}
