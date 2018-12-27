using System;

namespace pg.DarkSky.Wpf.ViewModels
{
    public class ForecastViewModel : ViewModelBase
    {

        private DateTimeOffset _time;
        public DateTimeOffset Time { get { return _time; } set { SetProperty(value, ref _time); } }

        private string _summary;
        public string Summary { get { return _summary; } set { SetProperty(value, ref _summary); } }

        private string _icon;
        public string Icon { get { return _icon; } set { SetProperty(value, ref _icon); } }

        private double _temperature;
        public double Temperature { get { return _temperature; } set { SetProperty(value, ref _temperature); } }

        private double _apparentTemperature;
        public double ApparentTemperature { get { return _apparentTemperature; } set { SetProperty(value, ref _apparentTemperature); } }

        private double _atmosphericPressure;
        public double AtmosphericPressure { get { return _atmosphericPressure; } set { SetProperty(value, ref _atmosphericPressure); } }

        private double _windSpeed;
        public double WindSpeed { get { return _windSpeed; } set { SetProperty(value, ref _windSpeed); } }

        private double _humidity;
        public double Humidity { get { return _humidity; } set { SetProperty(value, ref _humidity); } }

        private int _uvIndex;
        public int UvIndex { get { return _uvIndex; } set { SetProperty(value, ref _uvIndex); } }

    }
}
