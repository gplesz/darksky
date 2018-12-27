namespace pg.DarkSky.Wpf.Models
{
    public class Language
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public Language(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}