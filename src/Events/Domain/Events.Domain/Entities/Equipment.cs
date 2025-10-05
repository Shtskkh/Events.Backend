using Events.Domain.SeedWorks;

namespace Events.Domain.Entities;

public class Equipment : IEntity<int>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public EquipmentType Type { get; set; }
}