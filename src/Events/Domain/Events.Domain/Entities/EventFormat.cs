using Events.Domain.SeedWorks;

namespace Events.Domain.Entities;

/// <summary>
///     Сущность формата мероприятия.
/// </summary>
public class EventFormat : IEntity<int>
{
	/// <summary>
	///     <inheritdoc />
	/// </summary>
	public int Id { get; set; }

	/// <summary>
	///     Именование формата.
	/// </summary>
	public string Title { get; set; }

	/// <summary>
	///     Мероприятия с форматом.
	/// </summary>
	public ICollection<Event> Events { get; set; }
}