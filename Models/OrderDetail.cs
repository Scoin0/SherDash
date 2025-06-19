using SherDash.Models.Enums;

namespace SherDash.Models;

public class OrderDetail
{
    public int Id { get; set; }
    public string? SalesNumber { get; set; }
    public Size? Size { get; set; }
    public string? ProductNumber { get; set; }
    public string? Description { get; set; }
    public int? Quantity { get; set; }
    public bool IsPicked { get; set; }
    public int? QuantitySold { get; set; }
}