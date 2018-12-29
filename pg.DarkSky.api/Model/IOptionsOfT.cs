namespace pg.DarkSky.api.Model
{
    /// <summary>
    /// Az Options patterns ideiglenes megoldása
    /// </summary>
    /// <typeparam name="TOptions"></typeparam>
    public interface IOptions<out TOptions>
        where TOptions : class, new()
    {
        TOptions Value { get; }
    }
}
