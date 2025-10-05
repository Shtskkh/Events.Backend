using Events.Domain.SeedWorks;

namespace Events.Domain.Entities;

public class Location : IEntity<int>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public ICollection<Place> Places { get; set; }
}