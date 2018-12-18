using System;

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

        public Model.ApiResult<Model.FromDarkSky.ApiResponse> GetCurrentAndDailyData()
        {
            return new Model.ApiResult<Model.FromDarkSky.ApiResponse> { HasSuccess = true };
        }

        /// <summary>
        /// A szerviz indítása
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
        }


    }
}
