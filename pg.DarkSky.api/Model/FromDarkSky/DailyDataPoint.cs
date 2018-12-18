namespace pg.DarkSky.api.Model.FromDarkSky
{
    /// <summary>
    /// Az egy heti előrejelzések API válasz osztálya a DarkSky api-ból (egy napi adatok)
    /// https://darksky.net/dev/docs#data-point
    /// </summary>
    public class DailyDataPoint
    {
        public int time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
        public int precipIntensity { get; set; }
        public int precipProbability { get; set; }
        public float temperature { get; set; }
        public float apparentTemperature { get; set; }
        public float dewPoint { get; set; }
        public float humidity { get; set; }
        public float pressure { get; set; }
        public float windSpeed { get; set; }
        public float windGust { get; set; }
        public int windBearing { get; set; }
        public float cloudCover { get; set; }
        public int uvIndex { get; set; }
        public float visibility { get; set; }
        public float ozone { get; set; }
    }
}
