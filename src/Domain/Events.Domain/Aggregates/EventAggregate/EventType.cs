using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.EventAggregate;

/// <summary>
///     Тип мероприятия.
/// </summary>
public class EventType : Entity<int>
{
    public static readonly EventType Conference = new(1, "Конференция");
    public static readonly EventType Meetup = new(2, "Митап");
    public static readonly EventType Concert = new(3, "Концерт");

    /// <summary>
    ///     Конструктор.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="title">Название типа мероприятия.</param>
    public EventType(int id, string title) : base(id)
    {
        TitleText = new Text(title);

        switch (TitleText.Value.Length)
        {
            case < DomainConstraints.Event.Type.MinLength:
                throw new DomainException(DomainErrorMessages.Event.Type.LessThanMinLenght);

            case > DomainConstraints.Event.Type.MaxLength:
                throw new DomainException(DomainErrorMessages.Event.Type.GreaterThanMaxLenght);
        }
    }

    private Text TitleText { get; }
    public string Title => TitleText.Value;
}