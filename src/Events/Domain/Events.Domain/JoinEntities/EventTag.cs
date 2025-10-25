using Events.Domain.Entities;

namespace Events.Domain.JoinEntities;

/// <summary>
///     Мероприятия с тегами.
/// </summary>
public class EventTag
{
	/// <summary>
	///     Идентификатор мероприятия.
	/// </summary>
	public Guid EventId { get; set; }

	/// <summary>
	///     Идентификатор тега.
	/// </summary>
	public int TagId { get; set; }

	/// <summary>
	///     Мероприятие.
	/// </summary>
	public Event Event { get; set; }

	/// <summary>
	///     Тег.
	/// </summary>
	public Tag Tag { get; set; }
}