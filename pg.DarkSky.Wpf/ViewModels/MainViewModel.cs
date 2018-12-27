using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace pg.DarkSky.Wpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        public MainViewModel()
        {
            RefreshDataCommand = new pgCommand(async (param) => { await RefreshData(); });
        }

        private bool _hasSuccess;
        public bool HasSuccess { get { return _hasSuccess; } set { SetProperty(value, ref _hasSuccess); } }

        private bool _isBusy;
        public bool IsBusy { get { return _isBusy; } set { SetProperty(value, ref _isBusy); } }

        private int _forecastApiCalls;
        public int ForecastApiCalls { get { return _forecastApiCalls; } set { SetProperty(value, ref _forecastApiCalls); } }

        private ForecastViewModel _current;
        public ForecastViewModel Current { get { return _current; } set { SetProperty(value, ref _current); } }

        private ObservableCollection<ForecastViewModel> _daily;
        public ObservableCollection<ForecastViewModel> Daily { get { return _daily; } set { SetProperty(value, ref _daily); } }

        #region Language Datasource to combobox
        private string _selectedLanguage;
        public string SelectedLanguage { get { return _selectedLanguage; } set { SetProperty(value, ref _selectedLanguage); } }

        private ObservableCollection<string> _selectableLanguage;
        public ObservableCollection<string> SelectableLanguage { get { return _selectableLanguage; } set { SetProperty(value, ref _selectableLanguage); } }
        #endregion Language Datasource to combobox

        #region City Datasource to combobox
        private string _selectedCity;
        public string SelectedCity { get { return _selectedCity; } set { SetProperty(value, ref _selectedCity); } }

        private ObservableCollection<string> _selectableCity;
        public ObservableCollection<string> SelectableCity { get { return _selectableCity; } set { SetProperty(value, ref _selectableCity); } }
        #endregion City Datasource to combobox

        #region data connection 
        public ICommand RefreshDataCommand { get; private set; }
        private Task RefreshData()
        {
            throw new NotImplementedException();
        }
        #endregion data connection 

    }
}
