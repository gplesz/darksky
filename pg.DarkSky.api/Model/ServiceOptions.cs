namespace pg.DarkSky.api.Model
{
    /// <summary>
    /// A request service bemenő paraméterei
    /// </summary>
    public class ServiceOptions
    {
        public ServiceOptions()
        {}

        public ServiceOptions(string apiKey)
        {
            ApiKey = apiKey;
        }
        public string ApiKey { get; set; }
    }
}
