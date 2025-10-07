using Events.Domain.Entities;

namespace Events.Domain.JunctionEntities;

public class Participant
{
    public DateTime RegistrationTime { get; set; }
    
    // FKs
    public int EventId { get; set; }
    public int UserId { get; set; }
    
    //Navigation properties
    public Event Event { get; set; }
    public User User { get; set; }
}