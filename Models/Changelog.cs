namespace SherDash.Models;

public class Changelog
{
    public int Id { get; set; }
    public string VersionNumber { get; set; } = "1.0.0";
    public List<Change> Changes { get; set; } = [];
    public DateTime Date { get; set; }
}