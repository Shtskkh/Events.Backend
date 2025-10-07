using Events.Domain.Entities;

namespace Events.Domain.JunctionEntities;

public class Post
{
    public Uri Link { get; set; }
    
    // FKs
    public int ExternalServiceId { get; set; }
    public int EventId { get; set; }
    
    // Navigation properties
    public ExternalService ExternalService { get; set; }
    public Event Event { get; set; }
}