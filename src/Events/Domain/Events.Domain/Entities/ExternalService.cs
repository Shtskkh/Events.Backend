using Events.Domain.JoinEntities;
using Events.Domain.SeedWorks;

namespace Events.Domain.Entities;

/// <summary>
///     Сущность внешнего сервиса.
/// </summary>
public class ExternalService : IEntity<int>
{
	/// <summary>
	///     <inheritdoc />
	/// </summary>
	public int Id { get; set; }

	/// <summary>
	///     Наименование внешнего сервиса.
	/// </summary>
	public string Title { get; set; }

	/// <summary>
	///     Посты во внешнем сервисе.
	/// </summary>
	public ICollection<PostInExternalService> Posts { get; set; }
}