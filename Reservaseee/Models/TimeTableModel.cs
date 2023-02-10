namespace Reservaseee.Models;

public class TimeTableModel
{
    public TimeTableModel()
    {
        TimeModels = new List<TimeWindowModel>();
    }

    public List<TimeWindowModel> TimeModels { get; set; }

    public bool Reserve(TimeWindowModel timeWindow)
    {
        if (IsOccupied(timeWindow)) return false;

        TimeModels.Add(timeWindow);
        return true;
    }

    public bool IsOccupied(TimeWindowModel timeWindow)
    {
        return TimeModels
            .Any(it =>
                (it.Start >= timeWindow.Start && it.Start <= timeWindow.End) ||
                (it.End <= timeWindow.End && it.End >= timeWindow.Start) ||
                (timeWindow.Start >= it.Start && timeWindow.Start <= it.End) ||
                (timeWindow.End <= it.End && timeWindow.End >= it.Start)
            );
    }
    
    public List<TabularTimeTable> Tabular()
    {
        var tabular = new List<TabularTimeTable>();
        for (var i = 0; i < TimeModels.Count; i++)
        {
            var currentItem = TimeModels[i];
            var nextItem = i + 1 < TimeModels.Count ? TimeModels[i + 1] : null;
    
            tabular.Add(new TabularTimeTable(currentItem!.Start, currentItem.End, nextItem?.Start ?? currentItem.End));
        }
    
        return tabular.OrderBy(it => it.Start).ToList();
    }
}

public class TabularTimeTable
{
    public DateTime End;
    public DateTime NextStart;
    public DateTime Start;

    public TabularTimeTable(DateTime start, DateTime end, DateTime nextStart)
    {
        Start = start;
        End = end;
        NextStart = nextStart;
    }
}