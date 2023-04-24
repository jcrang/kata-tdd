namespace MarsRover;

public enum Direction
{
    N,
    S,
    E,
    W
}

public class Rover
{
    public (int X, int Y) Location { get; }
    public Direction Direction { get; }

    public Rover((int, int) location, Direction direction)
    {
        Location = location;
        Direction = direction;
    }

    public void ExecuteCommands(char[] commands)
    {
    }
}