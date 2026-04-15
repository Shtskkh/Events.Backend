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
    ///     Ошибки участников.
    /// </summary>
    public static class Participant
    {
        public const string NotFoundAny = "Участники мероприятия не найдены.";

        public const string AlreadyRegistered = "Пользователь уже зарегистрирован на мероприятие.";

        public const string RegistrationNotRequired = "Мероприятие не требует регистрации.";

        public const string NotFound = "Пользователь не является участником мероприятия.";

        public const string MaxCountMustBeSet =
            "Для мероприятия с регистрацией необходимо указать максимальное количество участников.";

        public const string MaxCountReached = "Достигнуто максимальное количество участников мероприятия.";
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