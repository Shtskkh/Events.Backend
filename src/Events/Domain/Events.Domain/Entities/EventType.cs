using Events.Domain.SeedWorks;

namespace Events.Domain.Entities;

/// <summary>
///     Сущность типа мероприятия.
/// </summary>
public class EventType : IEntity<int>
{
	/// <summary>
	///     <inheritdoc />
	/// </summary>
	public int Id { get; set; }

	/// <summary>
	///     Наименование типа.
	/// </summary>
	public string Title { get; set; }

	/// <summary>
	///     Мероприятия с типом.
	/// </summary>
	public ICollection<Event> Events { get; set; }

	/// <summary>
	///     Стандартное превью для типа.
	/// </summary>
	public EventTypePreviewPhoto PreviewPhoto { get; set; }
}