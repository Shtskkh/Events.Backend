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
    ///     Ошибки описания мероприятия.
    /// </summary>
    public static class Description
    {
        public const string GreaterThanMaxLength = "Описание мероприятия больше максимальной длины.";
    }

    /// <summary>
    ///     Ошибки временного промежутка мероприятия.
    /// </summary>
    public static class DateTimeRange
    {
        public const string StartLaterThanEnd =
            "Дата и время начала мероприятия не может быть равно или позднее дате и времени окончания";

        public const string DurationGreaterThanMax = "Длина мероприятия больше максимальной длины.";
    }

    /// <summary>
    ///     Ошибки типа мероприятия.
    /// </summary>
    public static class Type
    {
        public const string NotFoundAny = "Типы мероприятий не найдены.";
        public const string GreaterThanMaxLenght = "Название типа мероприятия больше максимальной длины.";

        public static string NotFoundById(int typeId)
        {
            return $"Тип мероприятия с ID: {typeId} не найден.";
        }
    }

    public static class Format
    {
        public const string NotFoundAny = "Форматы мероприятий не найдены.";

        public static string NotFoundById(int formatId)
        {
            return $"Формат мероприятия с ID: {formatId} не найден.";
        }
    }

    /// <summary>
    ///     Ошибки превью мероприятия.
    /// </summary>
    public static class Preview
    {
        public const string PlaceholderAndPreviewCannotBothBeSet =
            "Нельзя указать одновременно превью и плейсхолдер.";

        public const string PlaceholderAndPreviewCannotBothBeEmpty =
            "Необходимо указать либо превью, либо плейсхолдер.";
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

    public static class Placeholders
    {
        public const string NotFoundAny = "Плейсхолдеры мероприятий не найдены.";
    }
}