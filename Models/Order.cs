using SherDash.Models.Enums;

namespace SherDash.Models;

public class Order
{
    public int Id { get; set; }
    public required Customer Customer { get; set; }
    public string? PurchaseOrder { get; set; }
    public DateTime EntryDate { get; set; }
    public Status Status { get; set; }
    public bool IsDelivery { get; set; }
    public List<OrderDetail>? OrderDetail { get; set; } = [];
}