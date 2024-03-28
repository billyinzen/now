using FluentAssertions;
using Now.Service;
using NSubstitute;
using Xunit;

namespace Now.UnitTests.Service;

public class DateTimeOffsetServiceTests
{
    [Fact]
    public void Now_ReturnsCurrentTimestamp()
    {
        var sut = CreateSut();
        sut.Now.Should().BeCloseTo(DateTimeOffset.Now, TimeSpan.FromMilliseconds(1));
    }
    
    [Fact]
    public void NSub_ReturnsConfiguredTimestamp_WhenMocked()
    {
        // This isn't really necessary, but serves prove the example provided in Readme.md
        var mockTimestamp = new DateTimeOffset(2016, 4, 16, 9, 53, 17, TimeSpan.FromHours(-5));
        var dateTimeMock = Substitute.For<IDateTimeOffsetService>();
        dateTimeMock.Now.Returns(mockTimestamp);
        
        dateTimeMock.Now.Should().Be(mockTimestamp);
    }
    
    // Private Methods

    private DateTimeOffsetService CreateSut()
        => new();
}