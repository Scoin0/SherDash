namespace SherDash.Models;

public class Customer
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Contact>? Contact { get; set; } = [];
}