using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SherDash.Models;
using SherDash.Services;
using SherDash.Utils;

namespace SherDash.Controllers;

[Route("orders")]
public class OrderController : Controller
{
    private readonly JsonDataService<Order> _orderService;
    private readonly JsonDataService<Customer> _customerService;

    public OrderController()
    {
        _orderService = new JsonDataService<Order>("order.json");
        _customerService = new JsonDataService<Customer>("customer.json");
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        var orders = _orderService.LoadData();
        return View(orders);
    }

    // GET: /order/add
    [HttpGet("add")]
    public IActionResult Add()
    {
        var customers = _customerService.LoadData();
        ViewBag.CustomerList = new SelectList(customers, "Id", "Name");
        ViewBag.Status = new SelectList(EnumUtil.GetStatusList(), "Value", "Display");
        ViewBag.Size = new SelectList(EnumUtil.GetSizeList(), "Value", "Description");

        return View(new Order
        {
            EntryDate = DateTime.Today,
            OrderDetail = new List<OrderDetail> { new() }
        });
    }

    // POST: /order/add
    [HttpPost("add")]
    [ValidateAntiForgeryToken]
    public IActionResult Add(Order order)
    {
        if (!ModelState.IsValid)
        {
            var customers = _customerService.LoadData();
            ViewBag.CustomerList = new SelectList(customers, "Id", "Name");
            ViewBag.Status = new SelectList(EnumUtil.GetStatusList(), "Value", "Description");
            ViewBag.Size = new SelectList(EnumUtil.GetSizeList(), "Value", "Description");

            return View(order);
        }

        var orders = _orderService.LoadData();
        order.Id = _orderService.GetNextId(orders);

        for (int i = 0; i < order.OrderDetail?.Count; i++)
        {
            order.OrderDetail[i].Id = i + 1;
        }
        
        orders.Add(order);
        _orderService.SaveData(orders);

        return RedirectToAction(nameof(Index));
    }

    // POST: /order/remove
    [HttpPost("remove/{id}")]
    [ValidateAntiForgeryToken]
    public IActionResult Remove(int id)
    {
        var orders = _orderService.LoadData();
        var order = orders.FirstOrDefault(o => o.Id == id);

        if (order != null)
        {
            orders.Remove(order);
            _orderService.SaveData(orders);
        }

        return RedirectToAction(nameof(Index));
    }

    // GET: /order/edit
    [HttpGet("edit/{id}")]
    public IActionResult Edit(int id)
    {
        var orders = _orderService.LoadData();
        var order = orders.FirstOrDefault(o => o.Id == id);

        if (order == null)
            return NotFound();

        ViewBag.CustomerList = new SelectList(_customerService.LoadData(), "Id", "Name");
        ViewBag.Status = new SelectList(EnumUtil.GetStatusList(), "Value", "Description");
        ViewBag.Size = new SelectList(EnumUtil.GetSizeList(), "Value", "Description");

        return View(order);
    }
    
    // POST: /order/edit
    [HttpPost("edit/{id}")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Order updatedOrder)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.CustomerList = new SelectList(_customerService.LoadData(), "Id", "Name");
            ViewBag.Status = new SelectList(EnumUtil.GetStatusList(), "Value", "Description");
            ViewBag.Size = new SelectList(EnumUtil.GetSizeList(), "Value", "Description");
            return View(updatedOrder);
        }

        var orders = _orderService.LoadData();
        var existing = orders.FirstOrDefault(o => o.Id == updatedOrder.Id);

        if (existing == null)
            return NotFound();

        existing.PurchaseOrder = updatedOrder.PurchaseOrder;
        // ADD THE REST LATER.
        
        _orderService.SaveData(orders);
        
        return RedirectToAction(nameof(Index));
    }
}