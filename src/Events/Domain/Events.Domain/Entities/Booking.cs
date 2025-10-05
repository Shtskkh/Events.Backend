using Events.Domain.SeedWorks;

namespace Events.Domain.Entities;

public class Booking : IEntity<int>
{
    public int Id { get; set; }
    public Event Event { get; set; }
    public Place Place { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int ParticipantsCount { get; set; }
    public string Note { get; set; }
    public DateTime CreatedAt { get; set; }
}