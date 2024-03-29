﻿using AutoMapper;
using MahApps.Metro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using pg.DarkSky.Wpf.Helpers;
using pg.DarkSky.Wpf.Models;
using pg.DarkSky.Wpf.Properties;
using Serilog;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
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

            SettingsViewModel = new SettingsViewModel();

        }

        public MainViewModel(ForecastRepository forecastRepository, IMapper mapper, ILogger logger) : this()
        {
            this.forecastRepository = forecastRepository ?? throw new ArgumentNullException(nameof(forecastRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

            //Ezek csak az éles felhasználáshoz kellenek, ezért a default konstruktorba nem kellenek
            //todo: ezt elmenteni beállíthatónak
            SelectedCity = SelectableCity.Single(x => x.Coordinates == "47.49801,19.03991");
            var code = Settings.Default.Culture.LanguageNameToCode();
            SelectedLanguage = SelectableLanguage.Single(x => x.Code == code);

        }

        private bool _hasSuccess;
        public bool HasSuccess { get { return _hasSuccess; } set { SetProperty(value, ref _hasSuccess); } }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (SetProperty(value, ref _isBusy))
                {
                    OnPropertyChanged(nameof(IsNotBusy));
                }
            }
        }

        //Ez pedig a negáltja az egyszerűbb használathoz
        public bool IsNotBusy { get { return !IsBusy; } }

        private bool _isValid = false;
        /// <summary>
        /// Jelzi, hogy a képernyőn lévő adatok rendben vannak-e?
        /// vagyis a lenyílók és a megjelenített adatok egymáshoz tartoznak-e. Ha nem, akkor 
        /// false, ha igen, akkor true
        /// </summary>
        public bool IsValid
        {
            get { return _isValid; }
            set
            {
                SetProperty(value, ref _isValid);
                OnPropertyChanged(nameof(IsNotValid));
            }
        }

        //Ez pedig a negáltja az egyszerűbb használathoz
        public bool IsNotValid { get { return !IsValid; } }

        /// <summary>
        /// Ezt egyelőre nem használjuk, de ha egy task-ban mennek a feladatok, akkor ezzel automatikusan 
        /// lehet jelezni, mikor dolgozunk éppen
        /// </summary>
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

        private SettingsViewModel _settingsViewModel;
        public SettingsViewModel SettingsViewModel { get { return _settingsViewModel; } set { SetProperty(value, ref _settingsViewModel); } }


        #region Language Datasource to combobox
        private Language _selectedLanguage;
        public Language SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                if (SetProperty(value, ref _selectedLanguage))
                {
                    OnSelectedLanguageChanged(SelectedLanguage);
                    //jelezzük, hogy a képernyőn lévő adatok mér nem ehhez a lenyíló értékhez tartoznak
                    IsValid = false;
                }
            }
        }

        private void OnSelectedLanguageChanged(Language selectedLanguage)
        {
            var code = selectedLanguage.Code;
            //elmentjük későbbi használatra
            Settings.Default.Culture = code.CodeToLanguageName();
            Settings.Default.Save();
            Settings.Default.Reload();

            //Újratöltjük a szövegeket
            App.LoadCultureSettings(true);

            //szólunk, hogy változott a nyelv
            Current.RaiseLanguageChanged();
            foreach (var day in Daily)
            {
                day.RaiseLanguageChanged();
            }
        }

        private ObservableCollection<Language> _selectableLanguage;
        public ObservableCollection<Language> SelectableLanguage { get { return _selectableLanguage; } set { SetProperty(value, ref _selectableLanguage); } }
        #endregion Language Datasource to combobox

        #region City Datasource to combobox
        private City _selectedCity;
        public City SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                if (SetProperty(value, ref _selectedCity))
                {
                    //jelezzük, hogy a képernyőn lévő adatok mér nem ehhez a lenyíló értékhez tartoznak
                    IsValid = false;
                }
            }
        }

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
                    //A daily tab view nem enged csak az UI szálról adatot módosítani
                    App.Current.Dispatcher.Invoke(() => mapper.Map(result, this))
                    ;
                }
                else
                {
                    HasSuccess = false;
                    throw new Exception("Hiba történt az adatfrissítés közben");
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
                Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);
                if (HasSuccess)
                {
                    if (!appStyle.Item2.Name.Equals(GlobalStrings.Blue, StringComparison.OrdinalIgnoreCase))
                    {
                        ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(GlobalStrings.Blue), appStyle.Item1);
                    }
                }
                else
                {
                    if (!appStyle.Item2.Name.Equals(GlobalStrings.Red, StringComparison.OrdinalIgnoreCase))
                    {
                        ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(GlobalStrings.Red), appStyle.Item1);
                    }
                }

                IsBusy = false;
                IsValid = true;
                CommandManager.InvalidateRequerySuggested();
            }
        }
        #endregion data connection 



    }
}
