using pg.DarkSky.Wpf.Properties;
using System;
using System.Globalization;
using System.Linq;
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

            LoadCultureSettings(false);

            base.OnStartup(e);
        }

        /// <summary>
        /// Betölti a megfelelő nyelvi szövegeket
        /// </summary>
        /// <param name="mustBeDelete">Ha korábban már betöltöttük a szövegeket, akkor most először törölni kell </param>
        public static void LoadCultureSettings(bool mustBeDelete)
        {
            //Ez a felület nyelve miatt kell
            CultureInfo.DefaultThreadCurrentCulture =
                                CultureInfo.CreateSpecificCulture(Settings.Default.Culture);
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.DefaultThreadCurrentCulture;

            //ez pedig a nyelvi beállítások miatt (dátum, idő, számok)
            Thread.CurrentThread.CurrentCulture = CultureInfo.DefaultThreadCurrentCulture;
            //ez pedig a Humanize miatt kell
            Thread.CurrentThread.CurrentUICulture = CultureInfo.DefaultThreadCurrentCulture;

            if (mustBeDelete)
            {
                //ha korábban már betöltöttünk ilyet, akkor törölni kell
                var oldDicts = Application.Current.Resources
                                                  .MergedDictionaries
                                                  .Where(x => x.Source
                                                               .ToString()
                                                               .Contains("StringResources.")
                                                  ).ToList();

                for (int i = 0; i < oldDicts.Count(); i++)
                {
                    Application.Current.Resources
                                       .MergedDictionaries
                                       .Remove(oldDicts[i]);
                }
            }

            //beállítjuk az újat
            var culture = CultureInfo.DefaultThreadCurrentCulture;
            var dict = new ResourceDictionary
            {
                Source = new Uri($"pack://application:,,,/Resources/StringResources.{culture.Name}.xaml")
            };
            Application.Current.Resources
                               .MergedDictionaries
                               .Add(dict);
        }
    }
}
