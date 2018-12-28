using pg.DarkSky.Wpf.Helpers;
using pg.DarkSky.Wpf.Models;
using pg.DarkSky.Wpf.Properties;
using System;
using System.Globalization;
using System.Linq;
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

        private void CboSelectableLanguage_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            var code = ((Language)CboSelectableLanguage.SelectedItem).Code;
            //elmentjük későbbi használatra
            Settings.Default.Culture = code.CodeToLanguageName();
            Settings.Default.Save();
            Settings.Default.Reload();


            CultureInfo.DefaultThreadCurrentCulture =
                                CultureInfo.CreateSpecificCulture(Settings.Default.Culture);
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.DefaultThreadCurrentCulture;

            //ha korábban már betöltöttünk ilyet, akkor törölni kell
            var oldDicts = this.Resources
                               .MergedDictionaries
                               .Where(x => x.Source
                                            .ToString()
                                            .Contains("StringResources.")
                               ).ToList();

            for (int i = 0; i < oldDicts.Count(); i++)
            {
                this.Resources
                    .MergedDictionaries
                    .Remove(oldDicts[i]);
            }

            //beállítjuk az újat
            var culture = CultureInfo.DefaultThreadCurrentCulture;
            var dict = new ResourceDictionary
            {
                Source = new Uri($"pack://application:,,,/Resources/StringResources.{culture.Name}.xaml")
            };
            this.Resources.MergedDictionaries.Add(dict);

        }
    }
}
