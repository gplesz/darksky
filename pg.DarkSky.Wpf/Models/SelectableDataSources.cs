using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg.DarkSky.Wpf.Models
{
    public class SelectableDataSources
    {
        public static List<City> GetCities()
        {
            return new List<City>
            {
                new City("Budapest","47.49801,19.03991"),
                new City("Luxembourg","49.61167,6.13"),
                new City("Debrecen","47.53333,21.63333"),
                new City("Pécs","46.08333,18.23333"),
                new City("Wienna","48.20849,16.37208"),
                new City("Prague","50.08804,14.42076"),
                new City("München","48.13743,11.57549"),
                new City("Amsterdam","52.37403,4.88969"),
            };
        }

        public static List<Language> GetLanguages()
        {
            return new List<Language>
            {
                new Language("ar","Arabic"),
                new Language("az","Azerbaijani"),
                new Language("be","Belarusian"),
                new Language("bg","Bulgarian"),
                new Language("bs","Bosnian"),
                new Language("ca","Catalan"),
                new Language("cs","Czech"),
                new Language("da","Danish"),
                new Language("de","German"),
                new Language("en","English"),
                new Language("es","Spanish"),
                new Language("et","Estonian"),
                new Language("fi","Finnish"),
                new Language("fr","French"),
                new Language("he","Hebrew"),
                new Language("hr","Croatian"),
                new Language("hu","Hungarian"),
                new Language("id","Indonesian"),
                new Language("is","Icelandic"),
                new Language("it","Italian"),
                new Language("ja","Japanese"),
                new Language("ka","Georgian"),
                new Language("ko","Korean"),
                new Language("kw","Cornish"),
                new Language("lv","Latvian"),
                new Language("nb","Norwegian Bokmål"),
                new Language("nl","Dutch"),
                new Language("no","Norwegian Bokmål (alias for nb)"),
                new Language("pl","Polish"),
                new Language("pt","Portuguese"),
                new Language("ro","Romanian"),
                new Language("ru","Russian"),
                new Language("sk","Slovak"),
                new Language("sl","Slovenian"),
                new Language("sr","Serbian"),
                new Language("sv","Swedish"),
                new Language("tet","Tetum"),
                new Language("tr","Turkish"),
                new Language("uk","Ukrainian"),
                new Language("x-pig-latin","Igpay Atinlay"),
                new Language("zh","simplified Chinese"),
                new Language("zh-tw","traditional Chinese")
            };

        }
    }
}
