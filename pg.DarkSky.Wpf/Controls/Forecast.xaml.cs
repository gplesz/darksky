using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pg.DarkSky.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for ForecastControl.xaml
    /// </summary>
    public partial class Forecast : UserControl
    {
        public Forecast()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty WeatherIconProperty =
            DependencyProperty.Register("WeatherIcon", typeof(PackIconWeatherIconsKind), typeof(Forecast),
                                        new FrameworkPropertyMetadata(PackIconWeatherIconsKind.Na));
            //DependencyProperty.Register("WeatherIcon", typeof(PackIconWeatherIconsKind), typeof(ForecastControl));

        public PackIconWeatherIconsKind WeatherIcon
        {
            get { return (PackIconWeatherIconsKind)GetValue(WeatherIconProperty); }
            set { SetValue(WeatherIconProperty, value); }
        }

        public static readonly DependencyProperty WindspeedIconProperty =
            DependencyProperty.Register("WindspeedIcon", typeof(PackIconWeatherIconsKind), typeof(Forecast),
                                        new FrameworkPropertyMetadata(PackIconWeatherIconsKind.Na));

        public PackIconWeatherIconsKind WindspeedIcon
        {
            get { return (PackIconWeatherIconsKind)GetValue(WindspeedIconProperty); }
            set { SetValue(WindspeedIconProperty, value); }
        }

        public static readonly DependencyProperty WindSpeedTextProperty =
            DependencyProperty.Register("WindSpeedText", typeof(string), typeof(Forecast),
                                        new FrameworkPropertyMetadata(string.Empty));

        public string WindSpeedText
        {
            get { return GetValue(WindSpeedTextProperty).ToString(); }
            set { SetValue(WindSpeedTextProperty, value); }
        }

        public static readonly DependencyProperty AtmosphericPressureTextProperty =
            DependencyProperty.Register("AtmosphericPressureText", typeof(string), typeof(Forecast),
                                        new FrameworkPropertyMetadata(string.Empty));

        public string AtmosphericPressureText
        {
            get { return GetValue(AtmosphericPressureTextProperty).ToString(); }
            set { SetValue(AtmosphericPressureTextProperty, value); }
        }

        public static readonly DependencyProperty HumidityTextProperty =
            DependencyProperty.Register("HumidityText", typeof(string), typeof(Forecast),
                                        new FrameworkPropertyMetadata(string.Empty));

        public string HumidityText
        {
            get { return GetValue(HumidityTextProperty).ToString(); }
            set { SetValue(HumidityTextProperty, value); }
        }

        public static readonly DependencyProperty TimeTextProperty =
            DependencyProperty.Register("TimeText", typeof(string), typeof(Forecast),
                                        new FrameworkPropertyMetadata(string.Empty));

        public string TimeText
        {
            get { return GetValue(TimeTextProperty).ToString(); }
            set { SetValue(TimeTextProperty, value); }
        }

        public static readonly DependencyProperty UvIndexProperty =
            DependencyProperty.Register("UvIndex", typeof(int), typeof(Forecast),
                                        new FrameworkPropertyMetadata(0));

        public int UvIndex
        {
            get { return (int)GetValue(UvIndexProperty); }
            set { SetValue(UvIndexProperty, value); }
        }

        public static readonly DependencyProperty TemperatureProperty =
            DependencyProperty.Register("Temperature", typeof(double), typeof(Forecast),
                                        new FrameworkPropertyMetadata(0d));

        public double Temperature
        {
            get { return (double)GetValue(TemperatureProperty); }
            set { SetValue(TemperatureProperty, value); }
        }

        public static readonly DependencyProperty ApparentTemperatureProperty =
            DependencyProperty.Register("ApparentTemperature", typeof(double), typeof(Forecast),
                                        new FrameworkPropertyMetadata(0d));

        public double ApparentTemperature
        {
            get { return (double)GetValue(ApparentTemperatureProperty); }
            set { SetValue(ApparentTemperatureProperty, value); }
        }


        public static readonly DependencyProperty SummaryProperty =
            DependencyProperty.Register("Summary", typeof(string), typeof(Forecast),
                                        new FrameworkPropertyMetadata(string.Empty));

        public string Summary
        {
            get { return GetValue(SummaryProperty).ToString(); }
            set { SetValue(SummaryProperty, value); }
        }

        public static readonly DependencyProperty UvIndexBackgroundColorProperty =
            DependencyProperty.Register("UvIndexBackgroundColor", typeof(SolidColorBrush), typeof(Forecast),
                                        new FrameworkPropertyMetadata(null));

        public SolidColorBrush UvIndexBackgroundColor
        {
            get { return (SolidColorBrush)GetValue(UvIndexBackgroundColorProperty); }
            set { SetValue(UvIndexBackgroundColorProperty, value); }
        }



    }
}
