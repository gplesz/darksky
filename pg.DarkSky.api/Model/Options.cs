namespace pg.DarkSky.api.Model
{
    public class Options<T> : IOptions<T>
        where T : class, new()
    {
        public Options(T value)
        {
            Value = value;
        }

        public T Value { get; }
    }
}
