using SherDash.Models.Enums;

namespace SherDash.Models;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string? PurchaseOrder { get; set; }
    public DateTime EntryDate { get; set; }
    public Status Status { get; set; }
    public bool IsDelivery { get; set; }
    public Delivery? Delivery { get; set; }
    public List<OrderDetail>? OrderDetail { get; set; } = [];
}