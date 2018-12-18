using System;
using pg.DarkSky.api.Model;
using pg.DarkSky.api.Model.FromDarkSky;
using pg.DarkSky.api.Service;
using TechTalk.SpecFlow;
using Xunit;

namespace pg.DarkSky.api.tests
{
    [Binding]
    public class ApiRequestsSteps
    {
        private RequestService service;
        private ApiResult<ApiResponse> result;

        [Given(@"egy API kapcsolat '(.*)' '(.*)' és '(.*)' adatokkal")]
        public void AmennyibenEgyAPIKapcsolatEsAdatokkal(string apiKey, string coordinates, string lang)
        {
            service = new Service.RequestService(apiKey, coordinates, lang);
        }

        [When(@"lekérdezem az időjárási adatokat")]
        public void MajdLekerdezemAzIdojarasiAdatokat()
        {
            result = service.GetCurrentAndDailyData();
        }
        
        [Then(@"a válasz true lesz")]
        public void AkkorAValaszTrueLesz()
        {
            Assert.True(result.HasSuccess);
        }
    }
}
