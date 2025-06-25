using System.ComponentModel;

namespace SherDash.Models.Enums;

public enum Status
{
    [Description("N/A")]
    None,
    [Description("Not Started")]
    NotStarted,
    [Description("In-Progress")]
    InProgress,
    [Description("Will Call")]
    WillCall,
    [Description("Finished")]
    Finished,
    [Description("Canceled")]
    Canceled
}