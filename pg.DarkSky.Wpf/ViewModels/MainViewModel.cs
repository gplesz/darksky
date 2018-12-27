using AutoMapper;
using pg.DarkSky.Wpf.Models;
using Serilog;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace pg.DarkSky.Wpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ForecastRepository forecastRepository;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        private CancellationTokenSource tcs;
        private Task task;

        public MainViewModel()
        {
            //átváltunk async/await-re, hogy a felület ne fagyjon le
            RefreshDataCommand = new pgCommand(async (param) => { await RefreshData(); }, (param) => !IsBusy );

            Current = new ForecastViewModel();
            Daily = new ObservableCollection<ForecastViewModel>();

            //todo: ezt betölteni egy beállításból
            SelectableLanguage = new ObservableCollection<Language>(SelectableDataSources.GetLanguages());
            SelectableCity = new ObservableCollection<City>(SelectableDataSources.GetCities());

            //todo: ezt elmenteni beállíthatónak
            SelectedCity = SelectableCity.Single(x => x.Coordinates == "47.49801,19.03991");
            SelectedLanguage = SelectableLanguage.Single(x=>x.Code == "hu");

        }

        public MainViewModel(ForecastRepository forecastRepository, IMapper mapper, ILogger logger) : this()
        {
            this.forecastRepository = forecastRepository ?? throw new ArgumentNullException(nameof(forecastRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private bool _hasSuccess;
        public bool HasSuccess { get { return _hasSuccess; } set { SetProperty(value, ref _hasSuccess); } }

        private bool _isBusy;
        public bool IsBusy { get { return _isBusy; } set { SetProperty(value, ref _isBusy); } }

        public bool IsWorking
        {
            get
            {
                if (task == null) { return false; }
                switch (task.Status)
                {
                    //Itt vannak azok az értékek, amikor nem fut a task
                    case TaskStatus.Created:
                    case TaskStatus.RanToCompletion:
                    case TaskStatus.Canceled:
                    case TaskStatus.Faulted:
                        return false;
                    //ezek pedig azok, ahol fut a task
                    case TaskStatus.Running:
                    case TaskStatus.WaitingForActivation:
                    case TaskStatus.WaitingToRun:
                    case TaskStatus.WaitingForChildrenToComplete:
                        return true;
                    default:
                        //ha ismeretlen task státusz van, akkor dobunk egy kivételt,
                        //mivel erre nincs a program felkészítve
                        throw new ArgumentOutOfRangeException($"task.Status ismeretlen: {task.Status}");
                }
            }
        }

        private int _forecastApiCalls;
        public int ForecastApiCalls { get { return _forecastApiCalls; } set { SetProperty(value, ref _forecastApiCalls); } }

        private ForecastViewModel _current;
        public ForecastViewModel Current { get { return _current; } set { SetProperty(value, ref _current); } }

        private ObservableCollection<ForecastViewModel> _daily;
        public ObservableCollection<ForecastViewModel> Daily { get { return _daily; } set { SetProperty(value, ref _daily); } }

        #region Language Datasource to combobox
        private Language _selectedLanguage;
        public Language SelectedLanguage { get { return _selectedLanguage; } set { SetProperty(value, ref _selectedLanguage); } }

        private ObservableCollection<Language> _selectableLanguage;
        public ObservableCollection<Language> SelectableLanguage { get { return _selectableLanguage; } set { SetProperty(value, ref _selectableLanguage); } }
        #endregion Language Datasource to combobox

        #region City Datasource to combobox
        private City _selectedCity;
        public City SelectedCity { get { return _selectedCity; } set { SetProperty(value, ref _selectedCity); } }

        private ObservableCollection<City> _selectableCity;
        public ObservableCollection<City> SelectableCity { get { return _selectableCity; } set { SetProperty(value, ref _selectableCity); } }
        #endregion City Datasource to combobox

        private string _errorMessage;
        public string ErrorMessage { get { return _errorMessage; } set { SetProperty(value, ref _errorMessage); } }


        #region data connection 
        public ICommand RefreshDataCommand { get; private set; }
        private async Task RefreshData()
        {
            //ha valami folyamatban van, nem hívjuk újra a frissítést
            if (IsBusy) { return; }
            IsBusy = true;

            tcs = new CancellationTokenSource();
            task = new Task(() =>
            {
                //todo: ha megállíthatónak akarjuk a frissítést, akkor legegyszerűbb a tcs-t továbbítani
                var result = forecastRepository.GetData(SelectedCity.Coordinates, SelectedLanguage.Code);
                tcs.Token.ThrowIfCancellationRequested();
                if (result.IsValid)
                {
                    mapper.Map(result, this);
                }
                else
                {
                    HasSuccess = false;
                    ErrorMessage = "Hiba történt az adatfrissítés közben";
                }
            }, tcs.Token);

            task.Start();

            //await-tal megvárjuk a végrehajtást, hogy frissítsük parancs hívhatóságát
            try
            {
                await Task.WhenAll(new Task[] { task });
            }
            catch (OperationCanceledException) //ezzel lekezeltük a Cancel-t
            { }
            catch (Exception ex)
            {
                //todo: a hibát jelezni a felületre
                HasSuccess = false;
                logger.Error(ex, "Hiba történt az adatfrissítés közben");
                ErrorMessage = "Hiba történt az adatfrissítés közben";
            }
            finally
            {
                IsBusy = false;
                CommandManager.InvalidateRequerySuggested();
            }
        }
        #endregion data connection 

        //https://github.com/MahApps/MahApps.Metro
        //https://www.nuget.org/packages/MahApps.Metro.IconPacks.WeatherIcons/


        //https://github.com/MahApps/MahApps.Metro.IconPacks
        //https://freebiesbug.com/illustrator-freebies/geometric-weather-icons/
        //https://www.graphicpear.com/weather-icons/

        //https://www.amcharts.com/free-animated-svg-weather-icons/
        //https://www.uplabs.com/posts/animated-svg-weather-icons
        //https://codepen.io/getreworked/pen/GpBpmg
        //https://codepen.io/noahblon/pen/lxukH
        //https://codemyui.com/simple-weather-animation-svg/
        //https://codemyui.com/cartoony-weather-animation/
        //https://www.bypeople.com/weather-icons-animated/
        //icons.set("clear-day", Skycons.CLEAR_DAY);
        //icons.set("clear-night", Skycons.CLEAR_NIGHT);
        //icons.set("partly-cloudy-day", Skycons.PARTLY_CLOUDY_DAY);
        //icons.set("partly-cloudy-night", Skycons.PARTLY_CLOUDY_NIGHT);
        //icons.set("cloudy", Skycons.CLOUDY);
        //icons.set("rain", Skycons.RAIN);
        //icons.set("sleet", Skycons.SLEET);
        //icons.set("snow", Skycons.SNOW);
        //icons.set("wind", Skycons.WIND);
        //icons.set("fog", Skycons.FOG);



        //fizetős
        //https://codecanyon.net/item/animated-svg-weather-icons/12631845
        //https://codecanyon.net/item/16-svg-weather-icons-animation-loops/16064045
        //http://www.vectorflower.com/preview/weather_icons/index.html

    }
}
