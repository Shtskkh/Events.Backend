using Events.Domain.Shared;
using Events.Domain.ValueObjects;

namespace Events.Domain.Entities;

public class ExternalService : Entity<int>
{
    public Title Title { get; }

    public ExternalService(int id, string title) : base(id)
    {
        Title = new Title(title);
    }
}