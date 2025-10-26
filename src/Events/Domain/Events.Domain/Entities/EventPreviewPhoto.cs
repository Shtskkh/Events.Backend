using Events.Domain.SeedWorks;

namespace Events.Domain.Entities;

/// <summary>
///     Сущность превью-фото мероприятия.
/// </summary>
public class EventPreviewPhoto : IFileEntity
{
	/// <summary>
	///     Идентификатор мероприятия.
	/// </summary>
	public Guid EventId { get; set; }

	/// <summary>
	///     Мероприятие.
	/// </summary>
	public Event Event { get; set; }

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