using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Events;

/// <summary>
///     Формат мероприятия.
/// </summary>
public class EventFormat : Entity<int>
{
    public static readonly EventFormat Online = new(1, "Онлайн");
    public static readonly EventFormat Offline = new(2, "Офлайн");
    public static readonly EventFormat Hybrid = new(3, "Гибрид");

    private EventFormat(int id, string title) : base(id)
    {
        Title = title;
    }

    public string Title { get; private set; }
}