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
    public (int X, int Y) Location { get; private set; }
    public Direction Direction { get; }

    public Rover((int, int) location, Direction direction)
    {
        Location = location;
        Direction = direction;
    }

    public void ExecuteCommands(char[] commands)
    {
        foreach (var command in commands)
        {
            if (command == 'f')
            {
                Location = (Location.X, Location.Y + 1);
            }

            if (command == 'b')
            {
                Location = (Location.X, Location.Y - 1);
            }
            //What does Nasa want us to do if command isn't f or b?
        }
    }
}