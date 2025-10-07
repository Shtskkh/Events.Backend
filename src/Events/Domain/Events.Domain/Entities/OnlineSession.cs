using Events.Domain.SeedWorks;

namespace Events.Domain.Entities;

public class OnlineSession : IEntity<int>
{
    public int Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public Uri Link { get; set; }
    public DateTime CreatedAt { get; set; }
    
    // FKs
    public int EventId { get; set; }
    
    // Navigation properties
    public Event Event { get; set; }
}