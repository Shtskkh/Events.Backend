using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Events;

/// <summary>
///     Тип мероприятия.
/// </summary>
public class EventType : Entity<int>
{
    public const int MaxTitleLength = 16;

    public static readonly EventType Conference = new(1, "Конференция");
    public static readonly EventType Meetup = new(2, "Митап");
    public static readonly EventType Concert = new(3, "Концерт");

    private EventType()
    {
    }

    public EventType(int id, string title) : base(id)
    {
        Title = new Text(title).Value;

        if (Title.Length > MaxTitleLength)
            throw new DomainException(EventTypeErrors.TitleGreaterThanMaxLenght);
    }

    public string Title { get; } = null!;
}