using Events.Domain.SeedWorks;

namespace Events.Domain.Entities;

public class ExternalService : IEntity<int>
{
    public int Id { get; set; }
    public string Title { get; set; }
}