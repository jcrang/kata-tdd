namespace BerlinClock;
public class Clock
{
    private readonly TimeOnly _timeOnly;

    public Clock(TimeOnly timeOnly)
    {
        _timeOnly = timeOnly;
    }

    public int MinuteUnits => _timeOnly.Minute % 5;
    public int MinuteFives => _timeOnly.Minute / 5;
    public int HourUnits => _timeOnly.Hour % 5;
    public int HourFives => _timeOnly.Hour / 5;
    public bool SecondParity => _timeOnly.Second % 2 == 1;
}