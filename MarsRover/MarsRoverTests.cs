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
    public void Rover_GivenEmptyCommandSet_NoChangeToDirectionOrLocation()
    {
        var marsRover = new Rover((1, 1), Direction.N);
        
        marsRover.ExecuteCommands(new char[]{});
        
        marsRover.Location.Should().Be((1, 1));
        marsRover.Direction.Should().Be(Direction.N);
    }
}