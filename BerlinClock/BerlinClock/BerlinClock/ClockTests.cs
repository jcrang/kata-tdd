using NUnit.Framework;

namespace BerlinClock;

[TestFixture]
public sealed class ClockTests
{
    [TestCase("00:00",0)]
    [TestCase("00:04",4)]
    [TestCase("00:05",0)]
    [TestCase("00:06",1)]
    [TestCase("00:10",0)]
    public void Clock_ShouldBeOfTypeIClock(string time, int minute)
    {
        var timeOnly = TimeOnly.Parse(time);
        var clock = new Clock(timeOnly);

        Assert.That(clock.Minute, Is.EqualTo(minute));
    }
    
    
}