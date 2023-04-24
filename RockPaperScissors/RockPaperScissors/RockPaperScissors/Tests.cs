using NUnit.Framework;

namespace RockPaperScissors;

public class Tests
{
    [TestCase(Choice.Rock, Choice.Rock, Outcome.Draw, "")]
    [TestCase(Choice.Rock, Choice.Paper, Outcome.Lose, "Paper covers Rock")]
    [TestCase(Choice.Rock, Choice.Scissors, Outcome.Win, "Rock smashes Scissors")]
    [TestCase(Choice.Rock, Choice.Lizard, Outcome.Win, "Rock crushes Lizard")]
    [TestCase(Choice.Rock, Choice.Spock, Outcome.Lose, "Spock vaporizes Rock")]
    [TestCase(Choice.Paper, Choice.Rock, Outcome.Win, "Paper covers Rock")]
    [TestCase(Choice.Paper, Choice.Paper, Outcome.Draw, "")]
    [TestCase(Choice.Paper, Choice.Scissors, Outcome.Lose, "Scissors cut Paper")]
    [TestCase(Choice.Paper, Choice.Lizard, Outcome.Lose, "Lizard eats Paper")]
    [TestCase(Choice.Paper, Choice.Spock, Outcome.Win, "Paper disproves Spock")]
    [TestCase(Choice.Scissors, Choice.Rock, Outcome.Lose, "Rock smashes Scissors")]
    [TestCase(Choice.Scissors, Choice.Paper, Outcome.Win, "Scissors cut Paper")]
    [TestCase(Choice.Scissors, Choice.Scissors, Outcome.Draw, "")]
    [TestCase(Choice.Scissors, Choice.Lizard, Outcome.Win, "Scissors decapitate Lizard")]
    [TestCase(Choice.Scissors, Choice.Spock, Outcome.Lose, "Spock smashes Scissors")]
    [TestCase(Choice.Lizard, Choice.Rock, Outcome.Lose, "Rock crushes Lizard")]
    [TestCase(Choice.Lizard, Choice.Paper, Outcome.Win, "Lizard eats Paper")]
    [TestCase(Choice.Lizard, Choice.Scissors, Outcome.Lose, "Scissors decapitate Lizard")]
    [TestCase(Choice.Lizard, Choice.Lizard, Outcome.Draw, "")]
    [TestCase(Choice.Lizard, Choice.Spock, Outcome.Win, "Lizard poisons Spock")]
    [TestCase(Choice.Spock, Choice.Rock, Outcome.Win, "Spock vaporizes Rock")]
    [TestCase(Choice.Spock, Choice.Paper, Outcome.Lose, "Paper disproves Spock")]
    [TestCase(Choice.Spock, Choice.Scissors, Outcome.Win, "Spock smashes Scissors")]
    [TestCase(Choice.Spock, Choice.Lizard, Outcome.Lose, "Lizard poisons Spock")]
    [TestCase(Choice.Spock, Choice.Spock, Outcome.Draw, "")]
    public void Play_ShouldReturnCorrectResult(Choice playerChoice, Choice opponentChoice, Outcome expectedOutcome, string expectedReason)
    {
        // Act
        var result = new Game().Play(playerChoice, opponentChoice);

        // Assert
        Assert.AreEqual(new Result(expectedOutcome, expectedReason), result);
    }
}

public class Game
{
    public Result Play(Choice player1, Choice player2)
    {
        if (player1 == player2)
        {
            return new Result(Outcome.Draw, "");
        }

        var reason = (player1, player2) switch
        {
            (Choice.Rock, Choice.Scissors) => "Rock smashes Scissors",
            (Choice.Paper, Choice.Rock) => "Paper covers Rock",
            (Choice.Scissors, Choice.Paper) => "Scissors cut Paper",
            (Choice.Lizard, Choice.Spock) => "Lizard poisons Spock",
            (Choice.Spock, Choice.Scissors) => "Spock smashes Scissors",
            (Choice.Scissors, Choice.Lizard) => "Scissors decapitate Lizard",
            (Choice.Lizard, Choice.Paper) => "Lizard eats Paper",
            (Choice.Paper, Choice.Spock) => "Paper disproves Spock",
            (Choice.Spock, Choice.Rock) => "Spock vaporizes Rock",
            (Choice.Rock, Choice.Lizard) => "Rock crushes Lizard",
            _ => ""
        };
        if (reason != "")
        {
            return new Result(Outcome.Win, reason);
        }

        reason = (player2, player1) switch
        {
            (Choice.Rock, Choice.Scissors) => "Rock smashes Scissors",
            (Choice.Paper, Choice.Rock) => "Paper covers Rock",
            (Choice.Scissors, Choice.Paper) => "Scissors cut Paper",
            (Choice.Lizard, Choice.Spock) => "Lizard poisons Spock",
            (Choice.Spock, Choice.Scissors) => "Spock smashes Scissors",
            (Choice.Scissors, Choice.Lizard) => "Scissors decapitate Lizard",
            (Choice.Lizard, Choice.Paper) => "Lizard eats Paper",
            (Choice.Paper, Choice.Spock) => "Paper disproves Spock",
            (Choice.Spock, Choice.Rock) => "Spock vaporizes Rock",
            (Choice.Rock, Choice.Lizard) => "Rock crushes Lizard",
            _ => ""
        };
        if (reason != "")
        {
            return new Result(Outcome.Lose, reason);
        }

        return new Result(Outcome.Lose, "");
    }
}