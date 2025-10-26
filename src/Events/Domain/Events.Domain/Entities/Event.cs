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

	/// <summary>
	///     Идентификатор типа мероприятия.
	/// </summary>
	public int EventTypeId { get; set; }

	/// <summary>
	///     Тип мероприятия.
	/// </summary>
	public EventType EventType { get; set; }

	/// <summary>
	///     Идентификатор формата мероприятия.
	/// </summary>
	public int EventFormatId { get; set; }

	/// <summary>
	///     Формат мероприятия.
	/// </summary>
	public EventFormat EventFormat { get; set; }
}