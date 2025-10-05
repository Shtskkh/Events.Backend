using Events.Domain.SeedWorks;

namespace Events.Domain.Entities;

public class Person : IEntity<int>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public Guid Avatar { get; set; }
    public Role Role { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Event> Events { get; set; }
    public ICollection<Event> EventsOrganized { get; set; }
}