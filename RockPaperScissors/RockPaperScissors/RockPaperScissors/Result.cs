namespace RockPaperScissors;

public enum Outcome
{
    Win,
    Draw,
    Lose
}

public record Result(Outcome Outcome, string Reason);