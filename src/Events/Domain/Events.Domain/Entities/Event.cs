using Events.Domain.JoinEntities;
using Events.Domain.SeedWorks;

namespace Events.Domain.Entities;

/// <summary>
///     Сущность мероприятия.
/// </summary>
public class Event : IEntity<Guid>
{
	/// <summary>
	///     <inheritdoc />
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	///     Теги мероприятия.
	/// </summary>
	public ICollection<Tag> Tags { get; set; }

	/// <summary>
	///     Мероприятия с тегами.
	/// </summary>
	public ICollection<EventTag> EventsTags { get; set; }
}