using System.ComponentModel.DataAnnotations;
using Events.Contracts.Shared;

namespace Events.Contracts.Users;

/// <summary>
///     Форма фильтра пользователей.
/// </summary>
public sealed record UserFilterDto : IPagination
{
    /// <summary>
    ///     Размер выборки.
    /// </summary>
    [Range(1, 30)]
    public required int Size { get; init; }

    /// <summary>
    ///     Страница выборки.
    /// </summary>
    [Range(1, int.MaxValue)]
    public required int Page { get; init; }
}