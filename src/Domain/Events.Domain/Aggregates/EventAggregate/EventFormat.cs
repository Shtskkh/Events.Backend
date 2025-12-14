using Events.Domain.Interfaces;
using Events.Domain.Shared;
using Events.Domain.ValueObjects;

namespace Events.Domain.Aggregates.EventAggregate;

/// <summary>
/// Формат мероприятия.
/// </summary>
public class EventFormat : Entity<int>
{
    public static readonly EventFormat Offline = new EventFormat(1, "Офлайн");
    public static readonly EventFormat Online = new EventFormat(2, "Онлайн");
    public static readonly EventFormat Hybrid = new EventFormat(3, "Гибрид");

    public Title Value { get; }

    private EventFormat(int id, string title) : base(id)
    {
        Value = new Title(title);
    }
}