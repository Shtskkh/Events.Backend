using Events.Domain.Shared;

namespace Events.Domain.Aggregates.EventAggregate;

/// <summary>
///     Формат мероприятия.
/// </summary>
public class EventFormat : Entity<int>
{
    /// <summary>
    ///     Онлайн мероприятие.
    /// </summary>
    public static readonly EventFormat Online = new(1, "Онлайн");

    /// <summary>
    ///     Офлайн мероприятие.
    /// </summary>
    public static readonly EventFormat Offline = new(2, "Офлайн");

    /// <summary>
    ///     Гибридное (онлайн + офлайн) мероприятие.
    /// </summary>
    public static readonly EventFormat Hybrid = new(3, "Гибрид");

    private EventFormat(int id, string title) : base(id)
    {
        Title = title;
    }

    /// <summary>
    ///     Название формата.
    /// </summary>
    public string Title { get; private set; }
}