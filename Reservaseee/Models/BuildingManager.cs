using System.Text.Json;

namespace Reservaseee.Models;

public class BuildingManager
{
    private static BuildingManager INSTANCE;

    public List<BuildingModel> Buildings = new();

    public BuildingManager()
    {
        Buildings = JsonSerializer.Deserialize<List<BuildingModel>>(File.OpenRead("data.json"))!;
    }

    public void Serialize()
    {
        File.WriteAllText(
            "data.json",
            JsonSerializer.Serialize(Buildings)
        );
    }

    public static BuildingManager GetInstance()
    {
        if (INSTANCE == null) INSTANCE = new BuildingManager();

        return INSTANCE;
    }
}