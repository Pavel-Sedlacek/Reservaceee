namespace Reservaseee.Models;

public class BuildingModel
{
    public BuildingModel(string name, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Rooms = new List<RoomModel>();
        Description = description;
    }

    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public List<RoomModel> Rooms { get; set; }
}