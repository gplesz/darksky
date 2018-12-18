namespace pg.DarkSky.api.Model.FromDarkSky
{
    /// <summary>
    /// Az aktuális időjárási értékek API válasz osztálya a DarkSky api-ból
    /// https://darksky.net/dev/docs#data-point
    /// 
    /// todo: összehangolható a DailyDataPoint-tal, ha van rá idő és kedv
    /// </summary>
    public class CurrentlyDataPoint
    {
        public long time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
        public double precipIntensity { get; set; }
        public double precipProbability { get; set; }
        public double temperature { get; set; }
        public double apparentTemperature { get; set; }
        public double dewPoint { get; set; }
        public double humidity { get; set; }
        public double pressure { get; set; }
        public double windSpeed { get; set; }
        public double windGust { get; set; }
        public int windBearing { get; set; }
        public double cloudCover { get; set; }
        public int uvIndex { get; set; }
        public double visibility { get; set; }
        public double ozone { get; set; }
    }
}
