using System;
using System.Collections.Generic;
using System.Text;

namespace pg.DarkSky.api.Model.FromDarkSky
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiResponse
    {
        public CurrentlyDataPoint currently { get; set; }
        public DailyDataBlock daily { get; set; }
    }
}
