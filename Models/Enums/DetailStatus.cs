using System.ComponentModel;

namespace SherDash.Models.Enums;

public enum DetailStatus
{
    [Description("Commited")]
    Commited,
    [Description("On Order")]
    OnOrder,
    [Description("Partial Commit")]
    PartialCommit
}