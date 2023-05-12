namespace InterviewRota;

public record Interviewer(string Name, int Effort)
{
    public string Name { get; } = Name;
    public int Effort { get; set; } = Effort;
}

public record Interview
{
    public string Name { get; }
    private readonly Action _onAbandon;
    private readonly Action _onAccept;

    public Interview(string name, Action onAbandon, Action onAccept)
    {
        Name = name;
        _onAbandon = onAbandon;
        _onAccept = onAccept;
    }

    public Interview Abandon()
    {
        _onAbandon();
        return this;
    }
    
    public Interview Accept()
    {
        _onAccept();
        return this;
    }
}

public class InterviewRota
{
    private readonly List<Interviewer> _list;

    public InterviewRota(IEnumerable<string> interviewers)
    {
        _list = interviewers.Select(x => new Interviewer(x, 0)).ToList();
    }

    public Interview GetNextInterviewer(int effort)
    {
        var interviewer = _list.MinBy(x => x.Effort);
        interviewer!.Effort += effort;

        return new Interview(interviewer.Name,
            () =>
            {
                interviewer.Effort -= effort;
            },
            () =>
            {
                _list.Remove(interviewer);
                _list.Add(interviewer);
            });
    }
}