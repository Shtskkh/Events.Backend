using Events.Domain.SeedWorks;

namespace Events.Domain.Entities;

public class Equipment : IEntity<int>
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    // FKs
    public int EquipmentTypeId { get; set; }
    
    // Navigation properties
    public EquipmentType EquipmentType { get; set; }
}