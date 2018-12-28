using pg.DarkSky.Wpf.Properties;
using System;
using System.Globalization;
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

            CultureInfo.DefaultThreadCurrentCulture =
                                CultureInfo.CreateSpecificCulture(Settings.Default.Culture);
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.DefaultThreadCurrentCulture;

            var culture = CultureInfo.DefaultThreadCurrentCulture;
            var dict = new ResourceDictionary
            {
                Source = new Uri($"pack://application:,,,/Resources/StringResources.{culture.Name}.xaml")
            };
            this.Resources.MergedDictionaries.Add(dict);

            base.OnStartup(e);
        }
    }
}
