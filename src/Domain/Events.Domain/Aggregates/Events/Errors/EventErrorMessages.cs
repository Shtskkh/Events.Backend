namespace Events.Domain.Aggregates.Events.Errors;

/// <summary>
///     Ошибки мероприятия.
/// </summary>
public static class EventErrorMessages
{
    public const string NotFoundByFilter = "Мероприятия по фильтру не найдены.";

    public static string NotFoundById(Guid eventId)
    {
        return $"Мероприятие с ID: {eventId} не найдено.";
    }

    /// <summary>
    ///     Ошибки бронирования аудиторий.
    /// </summary>
    public static class Booking
    {
        public const string LocationIdLessOrEqualToZero = "ID локации не может быть меньше или равен нулю.";

        public const string PlaceIdLessOrEqualToZero = "ID помещения не может быть меньше или равен нулю.";

        public const string NotAllowedForOnline = "Нельзя бронировать аудитории для онлайн мероприятий.";

        public const string RequiredForOfflineAndHybrid =
            "Бронирование помещения обязательно для офлайн или гибридных мероприятий.";

        public const string TimeConflict =
            "На выбранный временной промежуток уже существует бронирование, выберите другое время.";
    }
}