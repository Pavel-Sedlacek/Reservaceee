namespace Reservaseee.Models;

public class RoomModel
{
    public RoomModel(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        TimeTable = new TimeTableModel();
    }

    public Guid Id { get; set; }

    public TimeTableModel TimeTable { get; set; }

    public string Name { get; set; }

    public bool IsOccupied(TimeWindowModel timeWindow)
    {
        return TimeTable.IsOccupied(timeWindow);
    }

    public void Reserve(TimeWindowModel timeWindow)
    {
        TimeTable.Reserve(timeWindow);
    }

    public List<TabularTimeTable> Tabular()
    {
        return TimeTable.Tabular();
    }
}