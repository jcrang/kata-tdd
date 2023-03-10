namespace BerlinClock;
public class Clock
{
    private readonly TimeOnly _timeOnly;

    public Clock(TimeOnly timeOnly)
    {
        _timeOnly = timeOnly;
    }

    public int Minute
    {
        get
        {
            return _timeOnly.Minute % 5;
        }
    }
}