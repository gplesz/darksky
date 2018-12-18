using System.Collections.Generic;

namespace pg.DarkSky.api.Model.FromDarkSky
{
    /// <summary>
    /// Az egy heti előrejelzések API válasz osztálya a DarkSky api-ból (napi adatok összefoglalója)
    /// </summary>
    public class DailyDataBlock
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public List<DailyDataPoint> data { get; set; }
    }
}
