namespace Events.Contracts.Tags;

/// <summary>
///     Модель тэга.
/// </summary>
public sealed record TagDto
{
    /// <summary>
    ///     ID.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    ///     Тэг.
    /// </summary>
    public int Value { get; init; }
}