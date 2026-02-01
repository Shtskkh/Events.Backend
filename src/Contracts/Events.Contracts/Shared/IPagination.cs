namespace Events.Contracts.Shared;

/// <summary>
///     Пагинация.
/// </summary>
public interface IPagination
{
    /// <summary>
    ///     Размер выборки.
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    ///     Страница.
    /// </summary>
    public int Page { get; set; }
}