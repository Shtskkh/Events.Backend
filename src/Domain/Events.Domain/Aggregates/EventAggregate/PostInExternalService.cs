using Events.Domain.Entities;

namespace Events.Domain.Aggregates.EventAggregate;

public class PostInExternalService
{
    /// <summary>
    /// Id мероприятия.
    /// </summary>
    public Guid EventId { get; private set; }

    /// <summary>
    /// Id внешнего сервиса.
    /// </summary>
    public int ExternalServiceId { get; private set; }

    /// <summary>
    /// Мероприятие.
    /// </summary>
    public Event Event { get; private set; }

    /// <summary>
    /// Внешний сервис.
    /// </summary>
    public ExternalService ExternalService { get; private set; }

    /// <summary>
    /// Ссылка на пост.
    /// </summary>
    public Uri Link { get; private set; }

    public PostInExternalService(Guid eventId, int externalServiceId, Uri link)
    {
        EventId = eventId;
        ExternalServiceId = externalServiceId;
        Link = link;
    }
}