using Events.Domain.SeedWorks;

namespace Events.Domain.Entities;

public class PlaceType : IEntity<int>
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    // Navigation properties
    public ICollection<Place> Places { get; set; }
}