namespace pg.DarkSky.api.Model.FromDarkSky
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiResponse
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string timezone { get; set; }
        public CurrentlyDataPoint currently { get; set; }
        public DailyDataBlock daily { get; set; }
        public Flags flags { get; set; }
        public int offset { get; set; }
    }
}
