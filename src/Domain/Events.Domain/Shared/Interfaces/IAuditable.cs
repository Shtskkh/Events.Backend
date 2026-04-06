namespace Events.Domain.Shared.Interfaces;

/// <summary>
///     Интерфейс аудита.
/// </summary>
public interface IAuditable
{
    /// <summary>
    ///     Дата создания.
    /// </summary>
    DateTimeOffset CreatedAt { get; }

    /// <summary>
    ///     Дата обновления.
    /// </summary>
    DateTimeOffset UpdatedAt { get; }
}