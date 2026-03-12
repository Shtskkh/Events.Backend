namespace Events.Contracts.Features.Events.Participants;

/// <summary>
///     Участник мероприятия.
/// </summary>
public class ParticipantDto
{
    /// <summary>
    ///     Идентификатор.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    ///     Фамилия.
    /// </summary>
    public string LastName { get; init; } = null!;

    /// <summary>
    ///     Имя.
    /// </summary>
    public string FirstName { get; init; } = null!;

    /// <summary>
    ///     Отчество.
    /// </summary>
    public string? Patronymic { get; init; }

    /// <summary>
    ///     Дата и время регистрации.
    /// </summary>
    public DateTime RegistrationTime { get; init; }
}