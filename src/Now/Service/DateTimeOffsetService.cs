namespace Now.Service;

/// <summary>
/// Class defining methods and properties used when interacting with date and time information
/// </summary>
public class DateTimeOffsetService : IDateTimeOffsetService
{
    /// <inheritdoc/>
    public DateTimeOffset Now => DateTimeOffset.Now;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="DateTimeOffsetService"/> class
    /// </summary>
    public DateTimeOffsetService()
    {
    }
}