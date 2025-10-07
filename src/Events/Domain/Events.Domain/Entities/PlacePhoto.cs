namespace Events.Domain.Entities;

public class PlacePhoto
{
    public Guid Id { get; set; }
    
    // FKs
    public int PlaceId { get; set; }
    
    // Navigation properties
    public Place Place { get; set; }
}