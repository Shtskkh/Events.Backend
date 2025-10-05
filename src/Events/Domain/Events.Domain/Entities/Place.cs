using Events.Domain.SeedWorks;

namespace Events.Domain.Entities;

public class Place : IEntity<int>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Number { get; set; }
    public int Capacity { get; set; }
    public Location Location { get; set; }
    public PlaceType Type { get; set; }
    public ICollection<Equipment> Equipments { get; set; }
    public ICollection<Guid> Photos { get; set; }
}