using Microsoft.AspNetCore.Mvc;
using Reservaseee.Models;

namespace Reservaseee.Controllers;

public class BuildingsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View(BuildingManager.GetInstance().Buildings);
    }

    [HttpPost]
    public IActionResult Create(string name, string description)
    {
        BuildingManager.GetInstance().Buildings.Add(
            new BuildingModel(name, description)
        );
        BuildingManager.GetInstance().Serialize();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(Guid buildingId)
    {
        BuildingManager.GetInstance().Buildings.RemoveAll(it => it.Id == buildingId);
        BuildingManager.GetInstance().Serialize();

        return RedirectToAction("Index");
    }
}