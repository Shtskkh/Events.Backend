using Events.Domain.SeedWorks;

namespace Events.Domain.Entities;

/// <summary>
///     Сущность стандартного превью
///     для типа мероприятия.
/// </summary>
public class EventTypePreviewPhoto : IFileEntity
{
	/// <summary>
	///     Идентификатор типа мероприятия.
	/// </summary>
	public int EventTypeId { get; set; }

	/// <summary>
	///     Тип мероприятия.
	/// </summary>
	public EventType EventType { get; set; }

	/// <summary>
	///     <inheritdoc />
	/// </summary>
	public Guid Name { get; set; }

	/// <summary>
	///     <inheritdoc />
	/// </summary>
	public byte[] Content { get; set; }

	/// <summary>
	///     <inheritdoc />
	/// </summary>
	public string ContentType { get; set; }

	/// <summary>
	///     <inheritdoc />
	/// </summary>
	public int Size { get; set; }
}