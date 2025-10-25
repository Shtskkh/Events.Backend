using Events.Domain.JoinEntities;
using Events.Domain.SeedWorks;

namespace Events.Domain.Entities;

/// <summary>
///     Сущность тега.
/// </summary>
public class Tag : IEntity<int>
{
	/// <summary>
	///     <inheritdoc />
	/// </summary>
	public int Id { get; set; }

	/// <summary>
	///     Именование тега.
	/// </summary>
	public string Title { get; set; }

	/// <summary>
	///     Мероприятия с тегом.
	/// </summary>
	public ICollection<Event> Events { get; set; }

	/// <summary>
	///     Мероприятия с тегами.
	/// </summary>
	public ICollection<EventTag> EventsTags { get; set; }
}