using RestSharp;
using Serilog;
using System;
using System.Linq;

namespace pg.DarkSky.api.Service
{
    /// <summary>
    /// A DarkSky api lekérdezéséhez használható API Wrapper
    /// </summary>
    public class RequestService
    {
        //todo: ezt alkalmazás paraméterként be lehetne kérni, de nem változik, szóval a feladat miatt nem érdemes
        private readonly string host = "https://api.darksky.net";
        //todo: ahogy ezt is alkalmazás paraméterként be lehetne kérni, Option pattern-nel, mondjuk, attól függ, hogy az apikey honnan jön
        private readonly string apiKey;
        private RestClient client;
        private string xForecastApiCalls = "X-Forecast-API-Calls";

        private ILogger logger;
        /// <summary>
        /// A szerviz indítása
        /// 
        /// todo: azon lehet gondolkodni, hogy a paramétereket a konstruktor helyett a hívásba is tehetjük
        ///       konkrétan: az apikey marad itt, a coordinates és a language pedig hívásról hívásra változik.
        ///       Ez egyébként amúgyis így van, úgyhogy ezt 
        /// </summary>
        /// <param name="apiKey">api kulcs</param>
        public RequestService(string apiKey, ILogger logger)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException("message", nameof(apiKey));
            }
            this.apiKey = apiKey;

            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

            //a restclient nem nagyon cserélhető, így nincs sok értelme DI-vel bekérni
            client = new RestClient(host);

            logger.Debug("RequestService created");
        }

        /// <summary>
        /// Egy időjárás elpőrejelzés kérése
        /// </summary>
        /// <param name="coordinates">a koordináták szóköz nélkül, vesszővel elválasztva. pl.: "47.49801,19.03991"</param>
        /// <param name="language">nyelvi beállítás, ezen a nyelven válaszol az api</param>
        /// <returns></returns>
        public Model.ApiResult<Model.FromDarkSky.ApiResponse> GetCurrentAndDailyData(string coordinates, string language)
        {
            var request = new RestRequest("/forecast/{apiKey}/{coordinates}");
            request.AddUrlSegment("apiKey", apiKey);
            request.AddUrlSegment("coordinates", coordinates);

            request.AddParameter("exclude", "minutely,hourly,alerts");
            request.AddParameter("units", "si");
            request.AddParameter("lang", language);

            //todo: async hívást lehet ide tervezni, de mivel egyszer hívünk az alkalmazásból, nagy jelentősége most nincs
            //todo: tranziensre fel lehet készülni Polly-val
            //todo: tesztelni, hogy mi van, ha nincs egyáltalán hálózat
            var result = client.Execute<Model.FromDarkSky.ApiResponse>(request);

            if (!result.IsSuccessful)
            {
                logger.Error("Request to API {Host} was unsuccessful. Parameters: {coordinates}, {language} StatusCode: {StatusCode}, Description: {StatusDescription}",
                    coordinates, language,
                    host, result.StatusCode, result.StatusDescription);
                return new Model.ApiResult<Model.FromDarkSky.ApiResponse> { HasSuccess = false };
            }

            //kiolvassuk hányszor hívtuk a szolgáltatást ma
            var callHeader = result.Headers
                                   .FirstOrDefault(x => x.Name == xForecastApiCalls);
            //todo: ha nincs ilyen header, akkor most -1et adunk vissza, ezen lehet még töprengeni
            var callsHeaderValue = callHeader?.Value.ToString() ?? "-1";
            var callsNum = -1;
            if (int.TryParse(callsHeaderValue, out int calls))
            {
                callsNum = calls;
            }

            //todo: a flag-ben lehetnek még érdekes információk, például darksky-unavailable, ezt fel lehet dolgozni
            //https://darksky.net/dev/docs#response-flags

            if (logger.IsEnabled(Serilog.Events.LogEventLevel.Verbose))
            {
                logger.Debug("Request to API {Host} was successful. Forecast API calls: {ForecastApiCalls}. ResultData: {@Data}", host, calls, result.Data);
            }
            else
            {
                logger.Debug("Request to API {Host} was successful. Forecast API calls: {ForecastApiCalls}", host, calls);
            }

            return new Model.ApiResult<Model.FromDarkSky.ApiResponse>
            {
                HasSuccess = true,
                ForecastApiCalls = calls,
                Data = result.Data
            };
        }
    }
}
