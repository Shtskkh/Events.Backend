using System.Text.RegularExpressions;

namespace Events.Domain.Shared;

/// <summary>
///     Регулярные выражения.
/// </summary>
public static class RegularExpressions
{
    /// <summary>
    ///     Регулярное выражения для почтового адреса.
    /// </summary>
    public static readonly Regex Email = new("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$",
        RegexOptions.Compiled & RegexOptions.IgnoreCase);
}