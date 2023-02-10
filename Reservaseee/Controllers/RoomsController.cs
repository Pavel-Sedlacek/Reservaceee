using Microsoft.AspNetCore.Mvc;
using Reservaseee.Models;

namespace Reservaseee.Controllers;

public class RoomsController : Controller
{
    // GET
    public IActionResult Index(Guid id)
    {
        return View(BuildingManager.GetInstance().Buildings.Find(it => it.Id == id));
    }

    [HttpPost]
    public IActionResult Create(Guid id, string name)
    {
        BuildingManager.GetInstance().Buildings.Find(it => it.Id == id)!
            .Rooms.Add(new RoomModel(name));
        BuildingManager.GetInstance().Serialize();

        return RedirectToAction("Index", new { id });
    }

    [HttpPost]
    public IActionResult Delete(Guid buildingId, Guid roomId)
    {
        BuildingManager.GetInstance().Buildings.Find(it => it.Id == buildingId)?.Rooms.RemoveAll(it => it.Id == roomId);
        BuildingManager.GetInstance().Serialize();

        return RedirectToAction("Index");
    }
}