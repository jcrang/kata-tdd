using NUnit.Framework;

namespace InterviewRota;

[TestFixture]
public class InterviewRotaTests
{
    [Test]
    public void OneAddOne()
    {
        Assert.That(1 + 1, Is.EqualTo(2));
    }
}