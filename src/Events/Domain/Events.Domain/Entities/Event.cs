using Events.Domain.JunctionEntities;
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
    public Guid PreviewPhoto { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsPublic { get; set; }
    public bool NeedsRegistration { get; set; }
    
    //FKs
    public int EventTypeId { get; set; }
    public int EventFormatId { get; set; }
    public int OrganizerId { get; set; }
    
    // Navigation properties
    public EventType EventType { get; set; }
    public EventFormat EventFormat { get; set; }
    public User Organizer { get; set; }
    public ICollection<Tag> Tags { get; set; }
    public ICollection<Post> Posts { get; set; }
    public ICollection<Participant> Participants { get; set; }
    public ICollection<OnlineSession> OnlineSessions { get; set; }
    public ICollection<Booking> Bookings { get; set; }
}