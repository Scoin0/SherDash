using System.ComponentModel;

namespace SherDash.Models.Enums;

public enum Size
{
    [Description("N/A")]
    None,
    [Description("PINT")]
    Pint,
    [Description("QUART")]
    Quart,
    [Description("1/2 GAL")]
    HalfGallon,
    [Description("GAL")]
    Gallon,
    [Description("5 GAL")]
    FiveGallon,
    [Description("1KT")]
    OneKit,
    [Description("1.5KT")]
    OnePointFiveKit,
    [Description("2KT")]
    TwoKit,
    [Description("2.5KT")]
    TwoPointFiveKit,
    [Description("3KT")]
    ThreeKit,
    [Description("4KT")]
    FourKit,
    [Description("4 GAL")]
    FourGal,
    [Description("10KT")]
    TenKit,
    [Description("15KT")]
    FifteenKit,
    [Description("40/50#")]
    FortyFifty,
    [Description("MED")]
    MedCan,
    [Description("2''")]
    TwoInch,
    [Description("9''")]
    NineInch,
    [Description("EACH")]
    Each,
    [Description("KEG")]
    Keg,
    [Description("3LBS")]
    ThreePounds,
    [Description("27LBS")]
    TwentySevenPounds
}