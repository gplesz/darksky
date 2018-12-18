using System;
using TechTalk.SpecFlow;

namespace pg.DarkSky.api.tests
{
    [Binding]
    public class ApiRequestsSteps
    {
        [Given(@"egy API kapcsolat '(.*)' '(.*)' és '(.*)' adatokkal")]
        public void AmennyibenEgyAPIKapcsolatEsAdatokkal(string apikey, string coordinates, string lang)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"lekérdezem az időjárási adatokat")]
        public void MajdLekerdezemAzIdojarasiAdatokat()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a válasz true lesz")]
        public void AkkorAValaszTrueLesz()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
