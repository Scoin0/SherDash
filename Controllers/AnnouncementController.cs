using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SherDash.Models;
using SherDash.Services;

namespace SherDash.Controllers;

[Route("announcement")]
public class AnnouncementController : Controller
{
    private readonly JsonDataService<Announcement> _service;

    public AnnouncementController()
    {
        _service = new JsonDataService<Announcement>("announcement.json");
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        var announcement = _service.LoadData();
        return View(announcement);
    }

    [HttpPost("edit")]
    public IActionResult Edit(Announcement announcement)
    {
        return null;
    }
}