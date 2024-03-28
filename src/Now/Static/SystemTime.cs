namespace Now.Static;

/// <summary>
/// Static <see cref="DateTimeOffset"/> accessor allowing values to be fixed for testing purposes
/// </summary>
public static class SystemTime
{
    private static readonly ThreadLocal<Func<DateTimeOffset>> SystemTimeFunction = new(() => () => DateTimeOffset.Now);

    /// <inheritdoc cref="DateTimeOffset.Now"/>
    /// <exception cref="NullReferenceException">Thrown when the SystemTimeFunction has not been configured</exception>
    public static DateTimeOffset Now 
        => SystemTimeFunction.Value?.Invoke() 
           ?? throw new NullReferenceException();

    /// <summary>
    /// Sets a fixed time for the current thread to return through <see cref="SystemTime"/>
    /// </summary>
    /// <param name="fixedDateTimeOffset">
    /// The <see cref="DateTimeOffset"/> value that <see cref="SystemTime.Now"/> should return
    /// </param>
    public static void Set(DateTimeOffset fixedDateTimeOffset)
        => SystemTimeFunction.Value = () => fixedDateTimeOffset;
    
    /// <summary>
    /// Resets the <see cref="SystemTime"/> class to return the current <see cref="DateTimeOffset.Now"/> 
    /// </summary>
    public static void Reset()
        => SystemTimeFunction.Value = () => DateTimeOffset.Now;
}