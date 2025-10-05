using Events.Domain.SeedWorks;

namespace Events.Domain.Entities;

public class Event : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Annoucement { get; set; }
    public string Description { get; set; }
    public TimeSpan Duration { get; set; }
    public int MaxParticipants { get; set; }
    public EventType Type { get; set; }
    public EventFormat Format { get; set; }
    public Person Organizer { get; set; }
    public Guid PreviewPhoto { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsPublic { get; set; }
    public bool NeedsRegistration { get; set; }
    public ICollection<Tag> Tags { get; set; }
    public ICollection<Post> Posts { get; set; }
    public ICollection<Person> Participants { get; set; }
    public ICollection<OnlineSession> OnlineSessions { get; set; }
}