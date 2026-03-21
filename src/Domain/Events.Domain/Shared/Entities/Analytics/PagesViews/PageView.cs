namespace Events.Domain.Shared.Entities.Analytics.PagesViews;

/// <summary>
///     Просмотр страницы.
/// </summary>
public class PageView : Entity<long>
{
    private PageView()
    {
    }

    /// <summary>
    ///     Конструктор.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="entityType">Тип запрашиваемой сущности.</param>
    /// <param name="entityId">ID запрашиваемой сущности.</param>
    /// <param name="userId">ID пользователя.</param>
    public PageView(long id, string entityType, Guid entityId, Guid? userId = null) : base(id)
    {
        UserId = userId;
        EntityId = entityId;
        EntityType = entityType;
        ViewedAt = DateTime.UtcNow;
    }

    /// <summary>
    ///     Тип запрашиваемой сущности.
    /// </summary>
    public string EntityType { get; private set; } = null!;

    /// <summary>
    ///     ID запрашиваемой сущности.
    /// </summary>
    public Guid EntityId { get; private set; }

    /// <summary>
    ///     Дата и время просмотра.
    /// </summary>
    public DateTime ViewedAt { get; private set; }

    /// <summary>
    ///     ID пользователя.
    /// </summary>
    public Guid? UserId { get; private set; }
}