namespace Events.Application.Services.Interfaces;

/// <summary>
///     Маркер трекинга просмотра страницы.
/// </summary>
public interface ITrackPageView
{
    /// <summary>
    ///     Тип запрашиваемой сущности.
    /// </summary>
    string EntityType { get; }

    /// <summary>
    ///     ID сущности.
    /// </summary>
    Guid EntityId { get; }
}