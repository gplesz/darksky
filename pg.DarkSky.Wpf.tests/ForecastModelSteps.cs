using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pg.DarkSky.api.Service;
using pg.DarkSky.Wpf.Models;
using pg.DarkSky.Wpf.Profiles;
using Serilog;
using System;
using TechTalk.SpecFlow;

namespace pg.DarkSky.Wpf.tests
{
    [Binding]
    public class ForecastModelSteps
    {
        private ILogger logger;
        private ForecastRepository repository;
        private ForecastModel data;
        private IMapper mapper;

        public ForecastModelSteps()
        {
            //a tesztben nincs DI így nekünk kell a loggert konfigurálni
            Log.Logger = new LoggerConfiguration()
                                .WriteTo.Console()
                                .CreateLogger();

            logger = Log.Logger;

            //a tesztben nincs DI így nekünk kell a mappert konfigurálni
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<ForecastProfile>();
            });

            mapper = config.CreateMapper();
        }

        [Given(@"egy ForecastRepository felparaméterezve  '(.*)' '(.*)' és '(.*)' adatokkal")]
        public void AmennyibenEgyForecastRepositoryFelparameterezveEsAdatokkal(string apiKey, string coordinates, string language)
        {
            logger.Information("Get service to API with {Coordinates} and {Language}", coordinates, language);
            var service = new RequestService(apiKey, coordinates, language);
            repository = new ForecastRepository(service, mapper);
        }
        
        [When(@"meghívom az előrejelzés kérését")]
        public void MajdMeghivomAzElorejelzesKereset()
        {
            data = repository.GetData();
        }
        
        [Then(@"megkapom a megfelelő adatokat ezzel az eredménnyel:  '(.*)'")]
        public void AkkorMegkapomAMegfeleloAdatokatEzzelAzEredmennyel(bool isOk)
        {
            Assert.IsNotNull(data);
        }
    }
}
