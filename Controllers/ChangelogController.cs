using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SherDash.Models;
using SherDash.Services;
using SherDash.Utils;

namespace SherDash.Controllers;

[Route("changelog")]
public class ChangelogController : Controller
{
    private readonly JsonDataService<Changelog> _service;
    
    public ChangelogController()
    {
        _service = new JsonDataService<Changelog>("changelog.json");
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        var changelog = _service.LoadData().OrderByDescending(c => c.Date).ToList();
        return View(changelog);
    }
    
    // GET: /changelog/add
    [HttpGet("add")]
    public IActionResult Add()
    {
        ViewBag.ChangeType = new SelectList(EnumUtil.GetChangeTypeList(), "Value", "Description");

        var changelog = new Changelog
        {
            Date = DateTime.Today
        };
        
        return View(changelog);
    }
    
    // POST: /changelog/add
    [HttpPost("add")]
    [ValidateAntiForgeryToken]
    public IActionResult Add(Changelog changelog)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.ChangeType = new SelectList(EnumUtil.GetChangeTypeList(), "Value", "Description");
            return View(changelog);
        }

        var log = _service.LoadData();
        changelog.Id = _service.GetNextId(log);
        
        log.Add(changelog);
        _service.SaveData(log);

        return RedirectToAction(nameof(Index));
    }
    
    // POST: /remove/{id}
    [HttpPost("remove/{id}")]
    [ValidateAntiForgeryToken]
    public IActionResult Remove(int id)
    {
        var changelog = _service.LoadData();
        var entry = changelog.FirstOrDefault(e => e.Id == id);

        if (entry != null)
        {
            changelog.Remove(entry);
            _service.SaveData(changelog);
        }

        return RedirectToAction(nameof(Index));
    }
}