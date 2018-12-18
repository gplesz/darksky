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
        private readonly string apiKey;
        private readonly string coordinates;
        private readonly string language;
        //todo: ezt alkalmazás paraméterként be lehetne kérni, de nem változik, szóval a feladat miatt nem érdemes
        private readonly string host = "https://api.darksky.net";
        private RestClient client;
        private string xForecastApiCalls = "X-Forecast-API-Calls";

        //todo: később DI-vel elkérni a naplózót
        private ILogger logger = Log.Logger;


        /// <summary>
        /// A szerviz indítása
        /// 
        /// todo: azon lehet gondolkodni, hogy a paramétereket a konstruktor helyett a hívásba is tehetjük
        /// </summary>
        /// <param name="apiKey">api kulcs</param>
        /// <param name="coordinates">a koordináták szóköz nélkül, vesszővel elválasztva. pl.: "47.49801,19.03991"</param>
        /// <param name="language">nyelvi beállítás, ezen a nyelven válaszol az api</param>
        public RequestService(string apiKey, string coordinates, string language)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException("message", nameof(apiKey));
            }

            if (string.IsNullOrWhiteSpace(coordinates))
            {
                throw new ArgumentException("message", nameof(coordinates));
            }

            if (string.IsNullOrEmpty(language))
            {
                throw new ArgumentException("message", nameof(language));
            }

            this.apiKey = apiKey;
            this.coordinates = coordinates;
            this.language = language;
            //a restclient nem nagyon cserélhető, így nincs sok értelme DI-vel bekérni
            client = new RestClient(host);

            logger.Debug("RequestService created with coordinates: {Coordinates}, language: {Language}", coordinates, language);
        }

        public Model.ApiResult<Model.FromDarkSky.ApiResponse> GetCurrentAndDailyData()
        {
            var request = new RestRequest("/forecast/{apiKey}/{coordinates}");
            request.AddUrlSegment("apiKey", apiKey);
            request.AddUrlSegment("coordinates", coordinates);

            request.AddParameter("exclude", "minutely,hourly,alerts");
            request.AddParameter("units", "si");
            request.AddParameter("lang", "hu");

            //todo: async hívást lehet ide tervezni, de mivel egyszer hívünk az alkalmazásból, nagy jelentősége most nincs
            var result = client.Execute<Model.FromDarkSky.ApiResponse>(request);

            if (!result.IsSuccessful)
            {
                logger.Error("Request to API {Host} was unsuccessful. StatusCode: {StatusCode}, Description: {StatusDescription}", 
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
