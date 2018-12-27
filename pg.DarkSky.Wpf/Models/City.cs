namespace pg.DarkSky.Wpf.Models
{
    public class City
    {
        public string Name { get; set; }
        public string Coordinates { get; set; }

        public City(string name, string coordinates)
        {
            Name = name;
            Coordinates = coordinates;
        }
    }
}