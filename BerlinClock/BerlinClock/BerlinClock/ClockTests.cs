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
    [TestCase("23:59",4)]
    public void Clock_ShouldCorrectlyReturnMinuteUnit(string time, int minute)
    {
        var timeOnly = TimeOnly.Parse(time);
        var clock = new Clock(timeOnly);

        Assert.That(clock.MinuteUnits, Is.EqualTo(minute));
    }    
    
    [TestCase("00:00",0)]
    [TestCase("00:04",0)]
    [TestCase("00:05",1)]
    [TestCase("00:10",2)]
    [TestCase("00:12",2)]
    [TestCase("00:15",3)]
    [TestCase("00:18",3)]
    [TestCase("00:20",4)]
    [TestCase("00:50",10)]
    [TestCase("00:55",11)]
    [TestCase("01:00",0)]
    [TestCase("02:00",0)]
    public void Clock_ShouldCorrectlyReturnMinuteFives(string time, int minuteFives)
    {
        var timeOnly = TimeOnly.Parse(time);
        var clock = new Clock(timeOnly);

        Assert.That(clock.MinuteFives, Is.EqualTo(minuteFives));
    }
    
    
    [TestCase("00:00",0)]
    [TestCase("00:30",0)]
    [TestCase("00:59",0)]
    [TestCase("01:00",1)]
    [TestCase("04:00",4)]
    [TestCase("05:00",0)]
    [TestCase("09:00",4)]
    [TestCase("10:00",0)]
    [TestCase("23:59",3)]
    public void Clock_ShouldCorrectlyReturnHourUnits(string time, int hourUnits)
    {
        var timeOnly = TimeOnly.Parse(time);
        var clock = new Clock(timeOnly);

        Assert.That(clock.HourUnits, Is.EqualTo(hourUnits));
    }
    
    [TestCase("00:00",0)]
    [TestCase("04:00",0)]
    [TestCase("05:00",1)]
    [TestCase("10:00",2)]
    [TestCase("15:00",3)]
    [TestCase("20:00",4)]
    [TestCase("23:59",4)]
    public void Clock_ShouldCorrectlyReturnHourFives(string time, int hourFives)
    {
        var timeOnly = TimeOnly.Parse(time);
        var clock = new Clock(timeOnly);

        Assert.That(clock.HourFives, Is.EqualTo(hourFives));
    }
    
    [TestCase("00:00:00", false)]
    [TestCase("00:00:01", true)]
    [TestCase("00:00:02", false)]
    public void Clock_ShouldCorrectlyReturnMinuteParity(string time, bool parity)
    {
        var timeOnly = TimeOnly.Parse(time);
        var clock = new Clock(timeOnly);

        Assert.That(clock.SecondParity, Is.EqualTo(parity));
    }
    
}