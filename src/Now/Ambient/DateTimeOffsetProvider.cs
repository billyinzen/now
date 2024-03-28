namespace Now.Ambient;

/// <summary>
/// Context-aware <see cref="DateTimeOffset"/> provider 
/// </summary>
public class DateTimeOffsetProvider
{
    /// <inheritdoc cref="DateTimeOffset.Now"/>
    public static DateTimeOffset Now
        => DateTimeOffsetProviderContext.Current?.Timestamp ?? DateTimeOffset.Now;
}