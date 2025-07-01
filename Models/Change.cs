using SherDash.Models.Enums;

namespace SherDash.Models;

public class Change
{
    public string Entry { get; set; } = string.Empty;
    public ChangeType ChangeType { get; set; }
}