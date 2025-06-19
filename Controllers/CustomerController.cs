using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SherDash.Models;
using SherDash.Services;

namespace SherDash.Controllers;

public class CustomerController : Controller
{
    private JsonDataService<Customer> _service = new("customer.json");

    public IActionResult Index()
    {
        var customers = _service.LoadData();
        return View(customers);
    }

    public IActionResult Add()
    {
        var customers = _service.LoadData();
        ViewBag.CustomerList = new SelectList(customers, "Id", "Name");
        return View();
    }

    [HttpPost]
    public IActionResult Add(Customer customer)
    {
        var list = _service.LoadData();
        customer.Id = _service.GetNextId(list);
        list.Add(customer);
        _service.SaveData(list);
        return RedirectToAction("Index");
    }
}