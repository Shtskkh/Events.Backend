using Events.Domain.Shared;
using Events.Domain.ValueObjects;

namespace Events.Domain.Aggregates.EventAggregate;

/// <summary>
/// Тип мероприятия.
/// </summary>
public class EventType : Entity<int>
{
    /// <summary>
    /// Наименование типа мероприятия.
    /// </summary>
    public Title Title { get; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="title">Наименование.</param>
    public EventType(int id, string title)
        : base(id)
    {
        Title = new Title(title);
    }
}