using System.ComponentModel;

namespace SherDash.Models.Enums;

public enum ChangeType
{
    [Description("N/A")]
    None,
    [Description("Added")]
    Added,
    [Description("Removed")]
    Removed,
    [Description("Changed")]
    Changed,
    [Description("Fixed")]
    Fixed
}