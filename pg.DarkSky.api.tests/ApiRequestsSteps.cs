using pg.DarkSky.api.Model;
using pg.DarkSky.api.Model.FromDarkSky;
using pg.DarkSky.api.Service;
using Serilog;
using TechTalk.SpecFlow;
using Xunit;
using Xunit.Abstractions;

namespace pg.DarkSky.api.tests
{
    [Binding]
    public class ApiRequestsSteps
    {
        private RequestService service;
        private ApiResult<ApiResponse> result;

        private ILogger logger;

        public ApiRequestsSteps(ITestOutputHelper output)
        {
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Verbose()
                        .WriteTo.TestOutput(output, Serilog.Events.LogEventLevel.Verbose)
                        .CreateLogger()
                        .ForContext<ApiRequestsSteps>();

            //todo: ha majd tudok rá egyszerű DI-t, akkor csinálom
            logger = Log.Logger;
        }

        [Given(@"egy API kapcsolat '(.*)' '(.*)' és '(.*)' adatokkal")]
        public void AmennyibenEgyAPIKapcsolatEsAdatokkal(string apiKey, string coordinates, string language)
        {
            logger.Information("Request to API with {Coordinates} and {Language}", coordinates, language);
            service = new Service.RequestService(apiKey, coordinates, language);
        }

        [When(@"lekérdezem az időjárási adatokat")]
        public void MajdLekerdezemAzIdojarasiAdatokat()
        {
            result = service.GetCurrentAndDailyData();
            logger.Information("Result arrived: {@Result}", result);

        }
        
        [Then(@"a válasz eredménye ez lesz: '(.*)' lesz")]
        public void AkkorAValaszEredmenyeEzLeszLesz(bool isOk)
        {
            logger.Information("Result must be valid: {IsOk}", isOk);

            if (isOk)
            {
                Assert.True(result.HasSuccess);
            }
            else
            {
                Assert.False(result.HasSuccess);
            }

        }
    }
}
