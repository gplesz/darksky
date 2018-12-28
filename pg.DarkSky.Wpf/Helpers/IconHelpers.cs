using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg.DarkSky.Wpf.Helpers
{
    public static class IconHelpers
    {
        /// <summary>
        /// A SkyCons icon azonosítókat átforgatjuk mahapps.Icon.wehater azonosítókká
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static PackIconWeatherIconsKind IconToWeatherIcon(this string icon)
        {
            switch (icon)
            {
                case "clear-day":
                    return PackIconWeatherIconsKind.DaySunny;
                case "clear-night":
                    return PackIconWeatherIconsKind.NightClear;
                case "partly-cloudy-day":
                    return PackIconWeatherIconsKind.DayCloudy;
                case "partly-cloudy-night":
                    return PackIconWeatherIconsKind.NightCloudy;
                case "cloudy":
                    return PackIconWeatherIconsKind.Cloudy;
                case "rain":
                    return PackIconWeatherIconsKind.Rain;
                case "sleet":
                    return PackIconWeatherIconsKind.Sleet;
                case "snow":
                    return PackIconWeatherIconsKind.Snow;
                case "wind":
                    return PackIconWeatherIconsKind.StrongWind;
                case "fog":
                    return PackIconWeatherIconsKind.Fog;
                default:
                    return PackIconWeatherIconsKind.Na;
            }
        }

        /// <summary>
        /// Átalakítja a szélsebességet, ami m/s-ban jön (SI) Beaufort skálává
        /// https://hu.wikipedia.org/wiki/Beaufort-sk%C3%A1la
        /// 
        /// todo: a wikipédia alapján a szél jellemzőit meg lehetne tooltip-ben jeleníteni
        /// </summary>
        /// <param name="windspeed"></param>
        /// <returns></returns>
        public static PackIconWeatherIconsKind WindSpeedToBeaufortIcon(this double windspeed)
        {
            if (windspeed <= 0.3d)
            {
                return PackIconWeatherIconsKind.WindBeaufort0;
            }
            if (windspeed <= 1.7d)
            {
                return PackIconWeatherIconsKind.WindBeaufort1;
            }
            if (windspeed <= 3.1d)
            {
                return PackIconWeatherIconsKind.WindBeaufort2;
            }
            if (windspeed <= 5.3d)
            {
                return PackIconWeatherIconsKind.WindBeaufort3;
            }
            if (windspeed <= 8.1d)
            {
                return PackIconWeatherIconsKind.WindBeaufort4;
            }
            if (windspeed <= 10.9d)
            {
                return PackIconWeatherIconsKind.WindBeaufort5;
            }
            if (windspeed <= 13.3d)
            {
                return PackIconWeatherIconsKind.WindBeaufort6;
            }
            if (windspeed <= 16.9d)
            {
                return PackIconWeatherIconsKind.WindBeaufort7;
            }
            if (windspeed <= 20.0d)
            {
                return PackIconWeatherIconsKind.WindBeaufort8;
            }
            if (windspeed <= 23.7d)
            {
                return PackIconWeatherIconsKind.WindBeaufort9;
            }
            if (windspeed <= 27.9d)
            {
                return PackIconWeatherIconsKind.WindBeaufort10;
            }
            if (windspeed <= 31.9d)
            {
                return PackIconWeatherIconsKind.WindBeaufort11;
            }
            if (windspeed <= 33.3d)
            {
                return PackIconWeatherIconsKind.WindBeaufort12;
            }

            //ha kifutottunk a skálából, jelezzük az érvénytelen értéket
            return PackIconWeatherIconsKind.Na;
        }
    }
}
