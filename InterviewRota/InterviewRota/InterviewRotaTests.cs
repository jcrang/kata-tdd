using FluentAssertions;
using NUnit.Framework;

namespace InterviewRota;

[TestFixture]
public class InterviewRotaTests
{
    [Test]
    public void GetNextInterviewer_OneInterviewer_ReturnsSameInterviewerTwice()
    {
        var rota = new InterviewRota(new[] {"Bob"});

        rota.GetNextInterviewer(0).Accept().Name.Should().Be("Bob");
        rota.GetNextInterviewer(0).Accept().Name.Should().Be("Bob");
    }
    
    [Test]
    public void GetNextInterviewer_TwoInterviewers_ReturnsSameInterviewersTwice()
    {
        var rota = new InterviewRota(new[] {"Bob", "Steve"});

        rota.GetNextInterviewer(0).Accept().Name.Should().Be("Bob");
        rota.GetNextInterviewer(0).Accept().Name.Should().Be("Steve");        
        rota.GetNextInterviewer(0).Accept().Name.Should().Be("Bob");
        rota.GetNextInterviewer(0).Accept().Name.Should().Be("Steve");
    }
    
    [Test]
    public void GetNextInterviewer_TwoInterviewersOneDoesFive_ReturnsOtherInterviewerFiveTimes()
    {
        var rota = new InterviewRota(new[] {"Bob", "Steve"});

        rota.GetNextInterviewer(5).Accept().Name.Should().Be("Bob");
        rota.GetNextInterviewer(1).Accept().Name.Should().Be("Steve");        
        rota.GetNextInterviewer(1).Accept().Name.Should().Be("Steve");        
        rota.GetNextInterviewer(1).Accept().Name.Should().Be("Steve");        
        rota.GetNextInterviewer(1).Accept().Name.Should().Be("Steve");        
        rota.GetNextInterviewer(1).Accept().Name.Should().Be("Steve");        
        rota.GetNextInterviewer(1).Accept().Name.Should().Be("Bob");
    }
    
    [Test]
    public void GetNextInterviewer_TwoInterviewersOneDelaysThenAbandonsDecision_OtherInterviewerShouldBeChosenUntilAbandoned()
    {
        var rota = new InterviewRota(new[] {"Bob", "Steve"});

        var bob = rota.GetNextInterviewer(5);
        bob.Name.Should().Be("Bob");
        
        rota.GetNextInterviewer(1).Accept().Name.Should().Be("Steve");
        bob.Abandon();
        
        rota.GetNextInterviewer(1).Accept().Name.Should().Be("Bob");        
    }
    
}