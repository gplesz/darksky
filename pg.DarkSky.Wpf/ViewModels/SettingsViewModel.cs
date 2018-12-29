using pg.DarkSky.Wpf.Properties;

namespace pg.DarkSky.Wpf.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel()
        {
            //hogy ne legyen Stackoverflow, egyből a fieldbe írunk
            _apiKey = Settings.Default.APIKey;
        }

        private string _apiKey;
        public string ApiKey
        {
            get { return _apiKey; }
            set
            {
                if (SetProperty(value, ref _apiKey))
                {
                    //Változott, akkor elmentjük
                    Settings.Default.APIKey = ApiKey;
                    Settings.Default.Save();
                    Settings.Default.Reload();
                }
            }
        }
    }
}
