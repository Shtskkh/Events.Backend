using Events.Contracts.Shared;

namespace Events.Contracts.Tags;

public sealed record TagFilterDto : IPagination
{
    /// <summary>
    ///     Название тэга (необязательно).
    /// </summary>
    public string? TitleLike { get; init; }

    /// <summary>
    ///     Размер выборки.
    /// </summary>
    public required int Size { get; init; }

    /// <summary>
    ///     Страница выборки.
    /// </summary>
    public required int Page { get; init; }
}