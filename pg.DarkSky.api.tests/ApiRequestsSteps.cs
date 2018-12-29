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
            logger = new LoggerConfiguration()
                            .MinimumLevel.Verbose()
                            .WriteTo.TestOutput(output, Serilog.Events.LogEventLevel.Verbose)
                            .CreateLogger()
                            .ForContext<ApiRequestsSteps>();
        }

        [Given(@"egy API kapcsolat '(.*)' paraméterrel")]
        public void AmennyibenEgyAPIKapcsolatEsAdatokkal(string apiKey)
        {
            logger.Information("Create API request service");
            service = new RequestService(new Options<ServiceOptions>(new ServiceOptions(apiKey)), logger);
        }

        [When(@"lekérdezem az időjárási adatokat '(.*)' és '(.*)' adatokkal")]
        public void MajdLekerdezemAzIdojarasiAdatokat(string coordinates, string language)
        {
            logger.Information("Request to API with {Coordinates} and {Language}", coordinates, language);
            result = service.GetCurrentAndDailyData(coordinates, language);
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
