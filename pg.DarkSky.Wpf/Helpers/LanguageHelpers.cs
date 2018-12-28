using System;

namespace pg.DarkSky.Wpf.Helpers
{
    /// <summary>
    /// A lokalizáció neve és az API language code között konvertál oda/vissza.
    /// </summary>
    public static class LanguageHelpers
    {
        /// <summary>
        /// Az API nyelvi kódjából Culture Language nevet készít az alkalmazás lokalizációjának a beállításához
        /// csak a magyar és az angol van implementálva, és ha nem magyar, akkor angol
        /// </summary>
        /// <param name="code">az API két karakteres code értéke</param>
        /// <returns>a lokalizáció öt karakteres (xx-XX) neve</returns>
        public static string CodeToLanguageName(this string code)
        {
            switch (code)
            {
                case "hu":
                    return "hu-HU";
                case "en":
                default:
                    return "en-US";
            }
        }

        /// <summary>
        /// A lokalizáció nevéből az API-nak megfelelő code-ot készít. 
        /// csak a magyar és az angol van implementálva, és ha nem magyar, akkor angol
        /// </summary>
        /// <param name="languageName">a lokalizáció öt karakteres (xx-XX) neve</param>
        /// <returns>az API két karakteres code értéke</returns>
        public static string LanguageNameToCode(this string languageName)
        {
            var code = languageName.Substring(2);

            if (code.Equals("hu", StringComparison.OrdinalIgnoreCase))
            {
                return "hu";
            }
            return "en";
        }
    }
}
