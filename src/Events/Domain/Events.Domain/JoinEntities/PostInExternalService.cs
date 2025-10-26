using Events.Domain.Entities;

namespace Events.Domain.JoinEntities;

/// <summary>
///     Посты во внешних сервисах.
/// </summary>
public class PostInExternalService
{
	/// <summary>
	///     Идентификатор внешнего сервиса.
	/// </summary>
	public int ExternalServiceId { get; set; }

	/// <summary>
	///     Внешний сервис.
	/// </summary>
	public ExternalService ExternalService { get; set; }

	/// <summary>
	///     Идентификатор мероприятия.
	/// </summary>
	public Guid EventId { get; set; }

	/// <summary>
	///     Мероприятие.
	/// </summary>
	public Event Event { get; set; }

	/// <summary>
	///     Ссылка на пост.
	/// </summary>
	public Uri Url { get; set; }
}