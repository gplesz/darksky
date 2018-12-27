namespace pg.DarkSky.Wpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private bool _hasSuccess;
        public bool HasSuccess { get { return _hasSuccess; } set { SetProperty(value, ref _hasSuccess); } }

        private bool _isBusy;
        public bool IsBusy { get { return _isBusy; } set { SetProperty(value, ref _isBusy); } }

        private int _forecastApiCalls;
        public int ForecastApiCalls { get { return _forecastApiCalls; } set { SetProperty(value, ref _forecastApiCalls); } }
    }
}
