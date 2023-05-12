namespace InterviewRota;

public record Interviewer(string Name, int Effort)
{
    public string Name { get; set; } = Name;
    public int Effort { get; set; } = Effort;
}

public class InterviewRota {
    private readonly Queue<Interviewer> _queue = new();

    public InterviewRota(IEnumerable<string> interviewers)
    {
        foreach (var interviewer in interviewers)
        {
            _queue.Enqueue(new Interviewer(interviewer, 0));
        }
    }

    public string GetNextInterviewer(int effort)
    {
        var interviewer = _queue.Dequeue();
        interviewer.Effort += effort;

        _queue.Enqueue(interviewer);
        return interviewer.Name;
    }
}