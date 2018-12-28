using MahApps.Metro.IconPacks;
using pg.DarkSky.Wpf.Helpers;
using System;
using System.Windows.Media;

namespace pg.DarkSky.Wpf.ViewModels
{
    public class ForecastViewModel : ViewModelBase
    {

        private DateTimeOffset _time;
        public DateTimeOffset Time
        {
            get { return _time; }
            set
            {
                if (SetProperty(value, ref _time))
                {
                    OnPropertyChanged(nameof(TimeText));
                    OnPropertyChanged(nameof(ShortTimeText));
                }
            }
        }

        private string _summary;
        public string Summary { get { return _summary; } set { SetProperty(value, ref _summary); } }

        private string _icon;
        public string Icon
        {
            get { return _icon; }
            set
            {
                if(SetProperty(value, ref _icon))
                { //ha változott az érték, jelezzük, hogy változott az ikon
                    OnPropertyChanged(nameof(WeatherIcon));
                }
            }
        }

        private double _temperature;
        public double Temperature
        {
            get { return Math.Round(_temperature,1); }
            set { SetProperty(value, ref _temperature); }
        }

        private double _apparentTemperature;
        public double ApparentTemperature
        {
            get { return Math.Round(_apparentTemperature,1); }
            set { SetProperty(value, ref _apparentTemperature); }
        }

        private double _atmosphericPressure;
        public double AtmosphericPressure
        {
            get { return _atmosphericPressure; }
            set
            {
                if (SetProperty(value, ref _atmosphericPressure))
                {
                    OnPropertyChanged(nameof(AtmosphericPressureText));
                }
            }
        }

        private double _windSpeed;
        public double WindSpeed
        {
            get { return _windSpeed; }
            set
            {
                if (SetProperty(value, ref _windSpeed))
                { //ha változott az érték, jelezzük, hogy változott az ikon és a tooltip szöveg
                    OnPropertyChanged(nameof(WindspeedIcon));
                    OnPropertyChanged(nameof(WindSpeedText));
                }
            }
        }

        private double _humidity;
        public double Humidity
        {
            get { return _humidity; }
            set
            {
                if (SetProperty(value, ref _humidity))
                {
                    OnPropertyChanged(nameof(HumidityText));
                }
            }
        }

        private int _uvIndex;
        public int UvIndex
        {
            get { return _uvIndex; }
            set
            {
                if (SetProperty(value, ref _uvIndex))
                {
                    OnPropertyChanged(nameof(UvIndexBackgroundColor));
                }
            }
        }


        public PackIconWeatherIconsKind WeatherIcon
        {
            get
            {
                return Icon.IconToWeatherIcon();
            }
            // az ExtendedBinding-nak szüksége van a TwoWayBinding-ra, így 
            // ezt implementálni kell, nem csinál semmit.
            set { }
        }

        public PackIconWeatherIconsKind WindspeedIcon
        {
            get
            {
                return WindSpeed.WindSpeedToBeaufortIcon();
            }
            // az ExtendedBinding-nak szüksége van a TwoWayBinding-ra, így 
            // ezt implementálni kell, nem csinál semmit.
            set { }
        }

        public string WindSpeedText
        {
            get
            {
                return $"({WindSpeed:0.0} m/s)";
            }
        }

        public string AtmosphericPressureText
        {
            get
            {
                return $"{AtmosphericPressure:0.0} hPa";
            }
        }

        public string HumidityText
        {
            get
            {
                return $"{Humidity:P0}";
            }
        }


        /// <summary>
        /// Ez alapján: https://www.met.hu/idojaras/humanmeteorologia/uv-b/ismerteto/
        /// 
        /// todo: a weboldalon meglévő szöveg alapján lehetne többet mondani az adott értékről
        /// </summary>
        public SolidColorBrush UvIndexBackgroundColor
        {
            get
            {
                if (UvIndex<=2.9d)
                {
                    return new SolidColorBrush(Colors.DeepSkyBlue);
                }

                if (UvIndex <= 4.9d)
                {
                    return new SolidColorBrush(Colors.Green);
                }
                if (UvIndex <= 6.9d)
                {
                    return new SolidColorBrush(Colors.Yellow);
                }
                if (UvIndex <= 7.9d)
                {
                    return new SolidColorBrush(Colors.Orange); //ez a weboldalon #FFC400
                }

                return new SolidColorBrush(Colors.Red);
            }
        }

        public string TimeText
        {
            get
            {
                var date = Time.ToLocalTime().DateTime;
                return $"{date.ToLongDateString()} {date.ToShortTimeString()}";
            }
        }

        public string ShortTimeText
        {
            get
            {
                var date = Time.ToLocalTime().DateTime;
                return $"{date.ToShortDateString()}";
            }
        }

        /// <summary>
        /// Ez azért kell, hogy ne oldjam fel az OnPorpertyChanged láthatóságát publicra, 
        /// mert csak ebben azesetben kell hívnom kívülről. Ha változik a nyelv, akkor 
        /// újra kell tölteni a dátumot, és ezt így lehet kívülről elérni
        /// </summary>
        internal void RaiseLanguageChanged()
        {
            OnPropertyChanged(nameof(TimeText));
            OnPropertyChanged(nameof(ShortTimeText));
        }
    }
}
