using Events.Domain.Entities;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.EventAggregate;

/// <summary>
/// Пост для мероприятия во внешнем сервисе.
/// </summary>
public class EventPost : Entity<Guid>
{
    /// <summary>
    /// Внешний сервис.
    /// </summary>
    public ExternalService ExternalService { get; }

    /// <summary>
    /// Ссылка на пост во внешнем сервисе.
    /// </summary>
    public Uri Link { get; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="externalService">Внешний сервис.</param>
    /// <param name="link">Ссылка во внешнем сервисе.</param>
    public EventPost(
        ExternalService externalService,
        Uri link) : base(Guid.NewGuid())
    {
        ExternalService = externalService;
        Link = link;
    }
}