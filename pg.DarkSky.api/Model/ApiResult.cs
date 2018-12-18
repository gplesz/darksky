namespace pg.DarkSky.api.Model
{
    /// <summary>
    /// Egy api válasz DTO
    /// </summary>
    public class ApiResult<T>
    {
        /// <summary>
        /// Jelzi, hogy a hívás sikeres volt-e vagy sem
        /// </summary>
        public bool HasSuccess { get; set; }

        /// <summary>
        /// A hívások száma a mai nap, az utolsóval együtt
        /// </summary>
        public int ForecastApiCalls { get; set; }

        public T Data { get; set; }
    }
}
