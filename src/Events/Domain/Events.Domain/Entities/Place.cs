using Events.Domain.SeedWorks;

namespace Events.Domain.Entities;

public class Place : IEntity<int>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Number { get; set; }
    public int Capacity { get; set; }
    
    // FKs
    public int LocationId { get; set; }
    public int TypeId { get; set; }
    
    // Navigation properties
    public Location Location { get; set; }
    public PlaceType Type { get; set; }
    public ICollection<Equipment> Equipments { get; set; }
    public ICollection<PlacePhoto> Photos { get; set; }
}