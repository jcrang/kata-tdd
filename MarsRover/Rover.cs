namespace MarsRover;

public enum Direction
{
    N,
    E,
    S,
    W
}

public class Rover
{
    public (int X, int Y) Location { get; private set; }
    public Direction Direction { get; private set; }

    public Rover((int, int) location, Direction direction)
    {
        Location = location;
        Direction = direction;
    }

    public void ExecuteCommands(char[] commands)
    {
        var directions = Enum.GetValues<Direction>();

        foreach (var command in commands)
        {
            var index = Array.IndexOf(directions, Direction);

            switch (command)
            {
                case 'f':
                    Location = (Location.X, Location.Y + 1);
                    break;
                case 'b':
                    Location = (Location.X, Location.Y - 1);
                    break;
                case 'l':
                    Direction = directions[(index + directions.Length - 1) % directions.Length];
                    break;
                case 'r':
                    Direction = directions[(index + 1) % directions.Length];
                    break;
            }

            //What does Nasa want us to do if command isn't f, b, l, or r?
        }
    }
}