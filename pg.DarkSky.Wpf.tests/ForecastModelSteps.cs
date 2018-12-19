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
            logger = new LoggerConfiguration()
                                .WriteTo.Console()
                                .CreateLogger();

            //a tesztben nincs DI így nekünk kell a mappert konfigurálni
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<ForecastProfile>();
            });

            mapper = config.CreateMapper();
        }

        [Given(@"egy ForecastRepository felparaméterezve  '(.*)' paraméterrel")]
        public void AmennyibenEgyForecastRepositoryFelparameterezveEsAdatokkal(string apiKey)
        {
            logger.Information("Create API request service");
            var service = new RequestService(apiKey, logger);
            logger.Information("Create forecast repository");
            repository = new ForecastRepository(service, mapper);
        }

        [When(@"meghívom az előrejelzés kérését '(.*)' és '(.*)' adatokkal")]
        public void MajdMeghivomAzElorejelzesKereset(string coordinates, string language)
        {
            logger.Information("Get service to API with {Coordinates} and {Language}", coordinates, language);
            data = repository.GetData(coordinates, language);
            logger.Information("Arrived result data: {@Data}", data);
        }

        [Then(@"megkapom a megfelelő adatokat ezzel az eredménnyel:  '(.*)'")]
        public void AkkorMegkapomAMegfeleloAdatokatEzzelAzEredmennyel(bool isOk)
        {
            logger.Information("The result must be valid: {IsOk}", isOk);
            Assert.IsNotNull(data);
        }
    }
}
