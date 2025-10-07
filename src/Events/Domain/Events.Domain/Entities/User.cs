using Events.Domain.JunctionEntities;
using Events.Domain.SeedWorks;

namespace Events.Domain.Entities;

public class User : IEntity<int>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public Guid? Avatar { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    
    // FKs
    public int RoleId { get; set; }
    
    // Navigation properties
    public Role Role { get; set; }
    public ICollection<Participant> Participation { get; set; }
    public ICollection<Event> EventsOrganized { get; set; }
}