using FluentAssertions;
using NUnit.Framework;

namespace InterviewRota;

[TestFixture]
public class InterviewRotaTests
{
    [Test]
    public void OneAddOne()
    {
        (1 + 1).Should().Be(2);
    }
}