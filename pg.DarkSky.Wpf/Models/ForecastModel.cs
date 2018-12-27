using AutoMapper;
using pg.DarkSky.api.Service;
using System.Collections.Generic;

namespace pg.DarkSky.Wpf.Models
{
    /// <summary>
    /// Az előrejelzési adatok közül a megjelenítendőket tartalmazó
    /// </summary>
    public class ForecastModel
    {
        /// <summary>
        /// Sikerült-e lekérdezni az adatokat?
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Az aktuális adatok
        /// </summary>
        public ForecastModelDataPoint Current { get; set; }

        /// <summary>
        /// Az egy heti előrejelzés napi adatai
        /// </summary>
        public List<ForecastModelDataPoint> Daily { get; set; }

        /// <summary>
        /// Az elhasznált hívások száma
        /// </summary>
        public int ForecastApiCalls { get; set; }
    }
}
