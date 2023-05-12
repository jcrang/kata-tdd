﻿using FluentAssertions;
using NUnit.Framework;

namespace InterviewRota;

[TestFixture]
public class InterviewRotaTests
{
    [Test]
    public void GetNextInterviewer_OneInterviewer_ReturnsSameInterviewerTwice()
    {
        var rota = new InterviewRota(new[] {"Bob"});

        rota.GetNextInterviewer(0).Should().Be("Bob");
        rota.GetNextInterviewer(0).Should().Be("Bob");
    }
    
    [Test]
    public void GetNextInterviewer_TwoInterviewers_ReturnsSameInterviewersTwice()
    {
        var rota = new InterviewRota(new[] {"Bob", "Steve"});

        rota.GetNextInterviewer(0).Should().Be("Bob");
        rota.GetNextInterviewer(0).Should().Be("Steve");        
        rota.GetNextInterviewer(0).Should().Be("Bob");
        rota.GetNextInterviewer(0).Should().Be("Steve");
    }
    
    [Test]
    public void GetNextInterviewer_TwoInterviewersOneDoesFive_ReturnsOtherInterviewerFiveTimes()
    {
        var rota = new InterviewRota(new[] {"Bob", "Steve"});

        rota.GetNextInterviewer(5).Should().Be("Bob");
        rota.GetNextInterviewer(1).Should().Be("Steve");        
        rota.GetNextInterviewer(1).Should().Be("Steve");        
        rota.GetNextInterviewer(1).Should().Be("Steve");        
        rota.GetNextInterviewer(1).Should().Be("Steve");        
        rota.GetNextInterviewer(1).Should().Be("Steve");        
        rota.GetNextInterviewer(1).Should().Be("Bob");
    }
}