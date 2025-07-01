using System.ComponentModel;
using SherDash.Models.Enums;

namespace SherDash.Utils;

public static class EnumUtil
{
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attr = field?.GetCustomAttributes(typeof(DescriptionAttribute), false)
            .FirstOrDefault() as DescriptionAttribute;

        return attr?.Description ?? value.ToString();
    }

    public static List<(string Value, string Display)> GetSizeList()
    {
        return Enum.GetValues(typeof(Size))
            .Cast<Size>()
            .Select(s => (Value: s.ToString(), Display: s.GetDescription()))
            .ToList();
    }

    public static List<(string Value, string Display)> GetStatusList()
    {
        return Enum.GetValues(typeof(Status))
            .Cast<Status>()
            .Select(s => (Value: s.ToString(), Display: s.GetDescription()))
            .ToList();
    }

    public static List<(string Value, string Display)> GetDetailStatusList()
    {
        return Enum.GetValues(typeof(DetailStatus))
            .Cast<DetailStatus>()
            .Select(d => (Value: d.ToString(), Display: d.GetDescription()))
            .ToList();
    }

    public static List<(string Value, string Display)> GetChangeTypeList()
    {
        return Enum.GetValues(typeof(ChangeType))
            .Cast<ChangeType>()
            .Select(c => (Value: c.ToString(), Display: c.GetDescription()))
            .ToList();
    }
}