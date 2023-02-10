using Microsoft.AspNetCore.Mvc;
using Reservaseee.Models;

namespace Reservaseee.Controllers;

public class RoomController : Controller
{
    // GET
    public IActionResult Index(Guid buildingId, Guid roomId)
    {
        ViewBag.buildingId = buildingId;
        return View(
            BuildingManager.GetInstance().Buildings
                .Find(it => it.Id == buildingId)!.Rooms
                .Find(it => it.Id == roomId)
        );
    }

    public IActionResult Create(DateTime start, DateTime end, string description, Guid buildingId, Guid roomId)
    {
        var t = BuildingManager.GetInstance().Buildings
            .Find(it => it.Id == buildingId)!.Rooms
            .Find(it => it.Id == roomId)!
            .TimeTable;
        var tw = new TimeWindowModel(start, end, description);
        t.Reserve(tw);
        BuildingManager.GetInstance().Serialize();

        return RedirectToAction("Index", new { buildingId, roomId });
    }
}