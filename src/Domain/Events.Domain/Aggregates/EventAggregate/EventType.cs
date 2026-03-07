using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.EventAggregate;

/// <summary>
///     Тип мероприятия.
/// </summary>
public class EventType : Entity<int>
{
    /// <summary>
    ///     Конференция.
    /// </summary>
    public static readonly EventType Conference = new(1, "Конференция");

    /// <summary>
    ///     Митап.
    /// </summary>
    public static readonly EventType Meetup = new(2, "Митап");

    /// <summary>
    ///     Концерт.
    /// </summary>
    public static readonly EventType Concert = new(3, "Концерт");

    private EventType()
    {
    }

    /// <summary>
    ///     Конструктор.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="title">Название типа мероприятия.</param>
    /// <exception cref="DomainException">
    ///     Ошибка правил домена.
    /// </exception>
    public EventType(int id, string title) : base(id)
    {
        var value = new Text(title).Value;

        switch (value.Length)
        {
            case < DomainConstraints.Event.Type.MinLength:
                throw new DomainException(DomainErrorMessages.Event.Type.LessThanMinLenght);

            case > DomainConstraints.Event.Type.MaxLength:
                throw new DomainException(DomainErrorMessages.Event.Type.GreaterThanMaxLenght);
        }

        Title = value;
    }

    /// <summary>
    ///     Строка названия типа мероприятия.
    /// </summary>
    public string Title { get; } = null!;
}