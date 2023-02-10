namespace Reservaseee.Models;

public class TimeWindowModel
{
    public TimeWindowModel(DateTime start, DateTime end, string description)
    {
        Start = start;
        End = end;
        Description = description;
    }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public string Description { get; set; }
}