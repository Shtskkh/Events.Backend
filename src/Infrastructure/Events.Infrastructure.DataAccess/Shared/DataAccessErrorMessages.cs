namespace Events.Infrastructure.DataAccess.Shared;

/// <summary>
///     Ошибки data access.
/// </summary>
public static class DataAccessErrorMessages
{
    /// <summary>
    ///     Ошибки мероприятия.
    /// </summary>
    public static class Event
    {
        /// <summary>
        ///     Мероприятие не найдено.
        /// </summary>
        public const string NotFound = "Мероприятие не найдено.";
    }
}