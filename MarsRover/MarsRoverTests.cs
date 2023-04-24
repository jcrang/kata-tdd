using FluentAssertions;
using NUnit.Framework;

namespace MarsRover;

[TestFixture]
public class MarsRoverTests
{
    [Test]
    public void Rover_LocationOneOneAndDirectionN_CreatesRoverInCorrectLocationAndDirection()
    {
        var marsRover = new Rover((1, 1), Direction.N);

        marsRover.Location.Should().Be((1, 1));
        marsRover.Direction.Should().Be(Direction.N);
    }

    [Test]
    public void ExecuteCommands_GivenEmptyCommandSet_RoverStaysWhereItIs()
    {
        var marsRover = new Rover((1, 1), Direction.N);

        marsRover.ExecuteCommands(new char[] { });

        marsRover.Location.Should().Be((1, 1));
        marsRover.Direction.Should().Be(Direction.N);
    }

    [TestCase('f', 2)]
    [TestCase('b', 0)]
    public void ExecuteCommands_GivenASingleMovement_LocationChanges(char command, int expectedY)
    {
        var marsRover = new Rover((1, 1), Direction.N);

        marsRover.ExecuteCommands(new[] {command});
        marsRover.Location.Should().Be((1, expectedY));
    }

    [TestCase(new[] {'f', 'f'}, 3)]
    public void ExecuteCommands_GivenMovement_LocationChanges(char[] commands, int expectedY)
    {
        var marsRover = new Rover((1, 1), Direction.N);

        marsRover.ExecuteCommands(commands);
        marsRover.Location.Should().Be((1, expectedY));
    }

    [TestCase('l', Direction.W)]
    [TestCase('r', Direction.E)]
    public void ExecuteCommands_GivenASingleTurn_DirectionChanges(char command, Direction expectedDirection)
    {
        var marsRover = new Rover((1, 1), Direction.N);

        marsRover.ExecuteCommands(new[] {command});
        marsRover.Direction.Should().Be((expectedDirection));
    }

    [TestCase('r', Direction.W, Direction.N)]
    [TestCase('r', Direction.S, Direction.W)]
    [TestCase('r', Direction.E, Direction.S)]
    [TestCase('r', Direction.N, Direction.E)]
    [TestCase('l', Direction.W, Direction.S)]
    [TestCase('l', Direction.S, Direction.E)]
    [TestCase('l', Direction.E, Direction.N)]
    [TestCase('l', Direction.N, Direction.W)]
    public void ExecuteCommands_GivenASingleTurn_DirectionChanges(char command, Direction initialDirection,
        Direction expectedDirection)
    {
        var marsRover = new Rover((1, 1), initialDirection);

        marsRover.ExecuteCommands(new[] {command});
        marsRover.Direction.Should().Be((expectedDirection));
    }
}