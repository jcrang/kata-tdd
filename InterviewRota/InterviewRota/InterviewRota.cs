namespace InterviewRota;

public record Interviewer(string Name, int Effort)
{
    public string Name { get; set; } = Name;
    public int Effort { get; set; } = Effort;
}

public class InterviewRota {
    private readonly List<Interviewer> _list;

    public InterviewRota(IEnumerable<string> interviewers)
    {
        _list = interviewers.Select(x => new Interviewer(x, 0)).ToList();
    }

    public string GetNextInterviewer(int effort)
    {

        var interviewer = _list.MinBy(x => x.Effort);
        _list.Remove(interviewer!);
        interviewer!.Effort += effort;
        _list.Add(interviewer);
        return interviewer.Name;
    }
}