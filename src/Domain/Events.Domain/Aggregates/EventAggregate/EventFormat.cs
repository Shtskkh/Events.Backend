using Events.Domain.Shared;
using Events.Domain.ValueObjects;

namespace Events.Domain.Aggregates.EventAggregate;

/// <summary>
/// Формат мероприятия.
/// </summary>
public class EventFormat : Entity<int>
{
    /// <summary>
    /// Офлайн.
    /// </summary>
    public static readonly EventFormat Offline = new EventFormat(1, "Офлайн");

    /// <summary>
    /// Онлайн.
    /// </summary>
    public static readonly EventFormat Online = new EventFormat(2, "Онлайн");

    /// <summary>
    /// Гибрид (офлайн + онлайн).
    /// </summary>
    public static readonly EventFormat Hybrid = new EventFormat(3, "Гибрид");

    /// <summary>
    /// Именование формата.
    /// </summary>
    public Title Value { get; }

    private EventFormat(int id, string title) : base(id)
    {
        Value = new Title(title);
    }
}