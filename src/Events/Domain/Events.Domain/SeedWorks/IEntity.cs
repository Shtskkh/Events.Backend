namespace Events.Domain.SeedWorks;

public interface IEntity<TKey>
{
    TKey Id { get; set; }
}