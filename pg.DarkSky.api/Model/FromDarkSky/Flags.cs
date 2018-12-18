using RestSharp.Deserializers;
using System.Collections.Generic;

namespace pg.DarkSky.api.Model.FromDarkSky
{
    /// <summary>
    /// Ha nem elérhetőek az adatok, akkor itt a darkskyunavailable
    /// mező jelzi, így ezt is érdemes deserializálni
    /// </summary>
    public class Flags
    {
        [DeserializeAs(Name = "darksky-unavailable")]
        public string darkskyunavailable { get; set; }
        public List<string> sources { get; set; }
        [DeserializeAs(Name = "nearest-station")]
        public double neareststation { get; set; }
        public string units { get; set; }
  }
}
