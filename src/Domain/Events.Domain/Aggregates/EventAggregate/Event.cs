using Events.Domain.Aggregates.EventAggregate.ValueObjects;
using Events.Domain.Shared;
using Events.Domain.Shared.Interfaces;

namespace Events.Domain.Aggregates.EventAggregate;

/// <summary>
///     Сущность мероприятия.
/// </summary>
public class Event : Entity<Guid>, IAggregateRoot
{
    /// <summary>
    ///     Конструктор мероприятия.
    /// </summary>
    /// <param name="id">Идентификатор мероприятия.</param>
    /// <param name="title">Название мероприятия.</param>
    /// <param name="announcement">Анонс (краткое описание) мероприятия.</param>
    /// <param name="description">Описание мероприятия.</param>
    public Event(Guid id, EventTitle title, EventAnnouncement announcement, EventDescription description) :
        base(id)
    {
        Title = title;
        Announcement = announcement;
        Description = description;
    }


    /// <summary>
    ///     Название мероприятия.
    /// </summary>
    public EventTitle Title { get; private set; }

    /// <summary>
    ///     Анонс (краткое описание мероприятия).
    /// </summary>
    public EventAnnouncement Announcement { get; private set; }

    /// <summary>
    ///     Описание мероприятия.
    /// </summary>
    public EventDescription Description { get; private set; }

    /// <summary>
    ///     Метод изменения названия мероприятия.
    /// </summary>
    /// <param name="title">Новое название.</param>
    public void ChangeTitle(string title)
    {
        Title = new EventTitle(title);
    }

    /// <summary>
    ///     Метод изменения анонса мероприятия.
    /// </summary>
    /// <param name="announcement">Новый анонс.</param>
    public void ChangeAnnouncement(string announcement)
    {
        Announcement = new EventAnnouncement(announcement);
    }

    /// <summary>
    ///     Метод изменения описания мероприятия.
    /// </summary>
    /// <param name="description">Новое описание.</param>
    public void ChangeDescription(string description)
    {
        Description = new EventDescription(description);
    }
}