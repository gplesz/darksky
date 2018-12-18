using System;
using TechTalk.SpecFlow;

namespace pg.DarkSky.Wpf.tests
{
    [Binding]
    public class ForecastModelSteps
    {
        [Given(@"egy ForecastModel felparaméterezve  '(.*)' '(.*)' és '(.*)' adatokkal")]
        public void AmennyibenEgyForecastModelFelparameterezveEsAdatokkal(string p0, string p1, string p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"meghívom az előrejelzés kérését")]
        public void MajdMeghivomAzElorejelzesKereset()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"megkapom a megfelelő adatokat ezzel az eredménnyel:  '(.*)'")]
        public void AkkorMegkapomAMegfeleloAdatokatEzzelAzEredmennyel(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
