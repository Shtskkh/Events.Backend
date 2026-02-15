namespace Events.Domain.Shared.Interfaces;

/// <summary>
///     Интерфейс аудита.
/// </summary>
public interface IAuditable
{
    /// <summary>
    ///     Дата создания.
    /// </summary>
    DateTime CreatedAt { get; }

    /// <summary>
    ///     Дата обновления.
    /// </summary>
    DateTime UpdatedAt { get; }
}