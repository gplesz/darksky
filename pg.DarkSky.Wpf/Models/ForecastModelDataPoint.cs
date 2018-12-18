using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg.DarkSky.Wpf.Models
{
    /// <summary>
    /// Egy előrejelzési időpont adatai
    /// 
    /// Ezt használjuk a napi adatokhoz és a heti előrejelzéshez is.
    /// </summary>
    public class ForecastModelDataPoint
    {
        //ezek kellenek
        //- Temperature
        //- Apparent(feels-like) temperature
        //- Atmospheric pressure
        //- Wind speed
        //- Humidity
        //- UV index

        /// <summary>
        /// Az adathoz tartozó időpont
        /// </summary>
        public DateTimeOffset Time { get; set; }

        /// <summary>
        /// Ha van szöveg, akkor azt is kérjük
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Ha van ikon akkor könnyebb a megjelenítés
        /// </summary>
        public string Icon { get; set; }

        public double Temperature { get; set; }
        public double ApparentTemperature { get; set; }
        public double AtmosphericPressure { get; set; }
        public double WindSpeed { get; set; }
        public double Humidity { get; set; }
        public int UvIndex { get; set; }


    }
}
