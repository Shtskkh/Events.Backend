using Events.Domain.Aggregates.EventAggregate.ValueObjects;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.EventAggregate;

public class Event : Entity<Guid>
{
    public Event(Guid id, EventTitle title, EventAnnouncement announcement, EventDescription description) :
        base(id)
    {
        Title = title;
        Announcement = announcement;
        Description = description;
    }

    public EventTitle Title { get; private set; }

    public EventAnnouncement Announcement { get; private set; }

    public EventDescription Description { get; private set; }

    public void ChangeTitle(string title)
    {
        Title = new EventTitle(title);
    }

    public void ChangeAnnouncement(string announcement)
    {
        Announcement = new EventAnnouncement(announcement);
    }

    public void ChangeDescription(string description)
    {
        Description = new EventDescription(description);
    }
}