using SherDash.Models;
using SherDash.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SherDash.Controllers;

[Route("customers")]
public class CustomerController : Controller
{
    private readonly JsonDataService<Customer> _service;

    public CustomerController()
    {
        _service = new JsonDataService<Customer>("customer.json");
    }
    
    [HttpGet("")]
    public IActionResult Index()
    {
        var customers = _service.LoadData();
        return View(customers);
    }
    
    [HttpGet("add")]
    public IActionResult Add()
    {
        ViewBag.CustomerList = GetCustomerSelectList();
        return View();
    }
    
    [HttpPost("add")]
    [ValidateAntiForgeryToken]
    public IActionResult Add(Customer customer)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.CustomerList = GetCustomerSelectList();
            return View(customer);
        }

        var list = _service.LoadData();
        customer.Id = _service.GetNextId(list);
        list.Add(customer);
        _service.SaveData(list);

        return RedirectToAction(nameof(Index));
    }

    // POST: /customer/remove/
    [HttpPost("remove/{id}")]
    [ValidateAntiForgeryToken]
    public IActionResult Remove(int id)
    {
        var list = _service.LoadData();
        var customer = list.FirstOrDefault(c => c.Id == id);

        if (customer != null)
        {
            list.Remove(customer);
            _service.SaveData(list);
        }

        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet("edit/{id}")]
    public IActionResult Edit(int id)
    {
        var customer = _service.LoadData().FirstOrDefault(c => c.Id == id);
        if (customer == null)
        {
            return NotFound();
        }

        return View(customer);
    }
    
    [HttpPost("edit")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Customer updatedCustomer)
    {
        if (!ModelState.IsValid)
            return View(updatedCustomer);

        var list = _service.LoadData();
        var index = list.FindIndex(c => c.Id == updatedCustomer.Id);
        if (index < 0)
            return NotFound();

        list[index] = updatedCustomer;
        _service.SaveData(list);

        return RedirectToAction(nameof(Index));
    }

    private SelectList GetCustomerSelectList()
    {
        var customers = _service.LoadData();
        return new SelectList(customers, "Id", "Name");
    }
}