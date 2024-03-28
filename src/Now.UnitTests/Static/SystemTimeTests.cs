using FluentAssertions;
using Now.Static;
using Xunit;

namespace Now.UnitTests.Static;

public class SystemTimeTests
{
    // Initialize
    
    [Fact]
    public void Reset_InitializesWithTheCurrentTime()
    {
        SystemTime.Now.Should().BeCloseTo(DateTimeOffset.Now, TimeSpan.FromMilliseconds(1));
    }
    
    // Set

    [Fact]
    public void Set_FixesTheSystemTime()
    {
        var timestamp = new DateTimeOffset(2013, 1, 7, 10, 15, 0, TimeSpan.Zero);
        SystemTime.Set(timestamp);
        SystemTime.Now.Should().Be(timestamp);
    }
    
    // Reset
    
    [Fact]
    public void Reset_ClearsTheFixedSystemTime()
    {
        var timestamp = new DateTimeOffset(2013, 1, 7, 10, 15, 0, TimeSpan.Zero);
        SystemTime.Set(timestamp);
        SystemTime.Reset();
        SystemTime.Now.Should().BeCloseTo(DateTimeOffset.Now, TimeSpan.FromMilliseconds(1));
    }
}