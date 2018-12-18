namespace pg.DarkSky.api.Model.FromDarkSky
{
    /// <summary>
    /// Az egy heti előrejelzések API válasz osztálya a DarkSky api-ból (egy napi adatok)
    /// https://darksky.net/dev/docs#data-point
    /// </summary>
    public class DailyDataPoint
    {
        public long time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }

        public long sunriseTime { get; set; }
        public long sunsetTime { get; set; }
        public long windGustTime { get; set; }
        public long uvIndexTime { get; set; }

        public double moonPhase { get; set; }
        public double precipIntensity { get; set; }
        public double precipIntensityMax { get; set; }
        public long precipIntensityMaxTime { get; set; }
        public double precipProbability { get; set; }
        public double precipAccumulation { get; set; }
        public string precipType { get; set; }
        public double temperatureHigh { get; set; }
        public long temperatureHighTime { get; set; }
        public double temperatureLow { get; set; }
        public long temperatureLowTime { get; set; }
        public double apparentTemperatureHigh { get; set; }
        public long apparentTemperatureHighTime { get; set; }
        public double apparentTemperatureLow { get; set; }
        public long apparentTemperatureLowTime { get; set; }
        public double dewPoint { get; set; }
        public double humidity { get; set; }
        public double pressure { get; set; }
        public double windSpeed { get; set; }
        public double windGust { get; set; }
        public double cloudCover { get; set; }
        public double visibility { get; set; }
        public double ozone { get; set; }
        public double temperatureMin { get; set; }
        public long temperatureMinTime { get; set; }
        public double temperatureMax { get; set; }
        public long temperatureMaxTime { get; set; }
        public double apparentTemperatureMin { get; set; }
        public long apparentTemperatureMinTime { get; set; }
        public double apparentTemperatureMax { get; set; }
        public long apparentTemperatureMaxTime { get; set; }

        public int windBearing { get; set; }
        public int uvIndex { get; set; }

    }
}
