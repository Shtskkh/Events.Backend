using Events.Domain.Aggregates.EventAggregate.ValueObjects;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.EventAggregate;

public class Event : Entity<Guid>
{
    public Event(Guid id, EventTitle title, EventAnnouncement announcement) : base(id)
    {
        Title = title;
        Announcement = announcement;
    }

    public EventTitle Title { get; private set; }

    public EventAnnouncement Announcement { get; private set; }

    public void ChangeTitle(string title)
    {
        Title = new EventTitle(title);
    }

    public void ChangeAnnouncement(string announcement)
    {
        Announcement = new EventAnnouncement(announcement);
    }
}