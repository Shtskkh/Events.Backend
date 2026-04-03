namespace Events.Domain.Shared;

/// <summary>
///     Сообщения об ошибках домена.
/// </summary>
public static class DomainErrorMessages
{
    /// <summary>
    ///     Ошибки текста.
    /// </summary>
    public static class Text
    {
        public const string NullOrWhiteSpace = "Текстовое поле не может быть null или пустым.";
    }

    /// <summary>
    ///     Ошибки мероприятия.
    /// </summary>
    public static class Event
    {
        /// <summary>
        ///     Ошибки названия мероприятия.
        /// </summary>
        public static class Title
        {
            public const string GreaterThanMaxLength = "Название мероприятия больше максимальной длины.";
        }

        /// <summary>
        ///     Ошибки анонса мероприятия.
        /// </summary>
        public static class Announcement
        {
            public const string GreaterThanMaxLength = "Анонс мероприятия больше максимальной длины.";
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
            public const string GreaterThanMaxLenght = "Название типа мероприятия больше максимальной длины.";
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
            public const string NotAllowedForOnline = "Нельзя бронировать аудитории для онлайн мероприятий.";

            public const string RequiredForOffline =
                "Бронирование помещения обязательно для офлайн или гибридных мероприятий.";

            public const string TimeConflict =
                "На выбранный временной промежуток уже существует бронирование, выберите другое время.";
        }
    }

    /// <summary>
    ///     Ошибки локаций.
    /// </summary>
    public static class Location
    {
        /// <summary>
        ///     Ошибки названия локации.
        /// </summary>
        public static class Title
        {
            public static readonly string GreaterThanMaxLength =
                $"Название локации больше максимальной длины в {DomainConstraints.Location.Title.MaxLength} символ(-ов).";
        }

        /// <summary>
        ///     Ошибки адреса локации.
        /// </summary>
        public static class Address
        {
            public static readonly string GreaterThanMaxLength =
                $"Адрес локации больше максимальной длины в {DomainConstraints.Location.Address.MaxLength} символ(-ов).";
        }
    }

    /// <summary>
    ///     Ошибки помещений.
    /// </summary>
    public static class Place
    {
        public const string NotFound = "Помещение не найдено.";

        /// <summary>
        ///     Ошибки названия помещения.
        /// </summary>
        public static class Title
        {
            public static readonly string GreaterThanMaxLength =
                $"Название помещения больше максимальной длины в {DomainConstraints.Place.Title.MaxLength} символ(-ов).";
        }

        /// <summary>
        ///     Ошибки номера помещения.
        /// </summary>
        public static class Number
        {
            public const string ContainsMinus =
                "Номер помещения не может быть отрицательным.";

            public const string AlreadyExists = "Помещение с таким номером в данной локации уже существует.";

            public static readonly string GreaterThanMaxLength =
                $"Номер помещения больше максимальной длины в {DomainConstraints.Place.Number.MaxLength} символ(-ов).";
        }

        /// <summary>
        ///     Ошибки вместимости.
        /// </summary>
        public static class Capacity
        {
            public const string CapacityLessOrEqualZero = "Вместимость помещения не может быть меньше или равна 0";
        }

        /// <summary>
        ///     Ошибки типа помещения.
        /// </summary>
        public static class Type
        {
            public static readonly string GreaterThanMaxLength =
                $"Название типа помещения больше максимальной длины в {DomainConstraints.Place.Type.MaxLength} символ(-ов).";
        }
    }

    /// <summary>
    ///     Ошибки пользователей.
    /// </summary>
    public static class User
    {
        public const string RoleAlreadyAssigned = "Роль уже присвоена.";

        public const string EmailAlreadyInUse = "Почтовый адрес уже используется.";

        /// <summary>
        ///     Ошибки ролей пользователей.
        /// </summary>
        public static class Role
        {
            public static readonly string GreaterThanMaxLength =
                $"Название роли пользователя больше максимальной длины в {DomainConstraints.User.Role.MaxLength} символ(-ов).";
        }

        /// <summary>
        ///     Ошибки ФИО пользователя.
        /// </summary>
        public static class PersonName
        {
            public static readonly string FirstNameGreaterThanMaxLength =
                $"Имя больше максимальной длины в {DomainConstraints.User.PersonName.MaxLength} символ(-ов).";

            public static readonly string LastNameGreaterThanMaxLength =
                $"Фамилия больше максимальной длины в {DomainConstraints.User.PersonName.MaxLength} символ(-ов).";

            public static readonly string PatronymicGreaterThanMaxLength =
                $"Отчество больше максимальной длины в {DomainConstraints.User.PersonName.MaxLength} символ(-ов).";
        }
    }

    /// <summary>
    ///     Ошибки почтового адреса.
    /// </summary>
    public static class Email
    {
        public const string Invalid = "Неверный формат почтового адреса.";

        public static readonly string GreaterThanMaxLength =
            $"Длина почтового адреса больше максимальной длины в {DomainConstraints.Email.MaxLength} символ(-ов).";
    }

    /// <summary>
    ///     Ошибки паролей.
    /// </summary>
    public static class Password
    {
        public const string OldPasswordDoesNotMatch = "Прежний пароль не совпадает.";

        public static readonly string Invalid =
            $"Пароль не может содержать следующие символы: " +
            $"{string.Join(", ", DomainConstraints.Password.InvalidCharacters.Select(FormatChar))}.";

        public static readonly string LessThanMinLength =
            $"Длина пароля меньше минимальной длины в {DomainConstraints.Password.MinLength} символ(-ов).";

        public static readonly string GreaterThanMaxLength =
            $"Длина пароля больше максимальной длины в {DomainConstraints.Password.MaxLength} символ(-ов).";

        /// <summary>
        ///     Вспомогательный метод для ошибки неправильного пароля.
        /// </summary>
        /// <param name="c">Символ.</param>
        /// <returns>Строковое представление неправильного символа.</returns>
        private static string FormatChar(char c)
        {
            return c switch
            {
                ' ' => "пробел",
                '\t' => "табуляция",
                '\n' => "перенос строки",
                _ => c.ToString()
            };
        }
    }

    /// <summary>
    ///     Ошибки фото.
    /// </summary>
    public static class Photo
    {
        public const string NotFound = "Фотография не найдена.";
        public const string AlreadyExists = "Фотография уже существует.";
        public const string InvalidOrder = "Порядок фотографии не может быть отрицательным.";
        public const string FileNameNullOrWhiteSpace = "Название файла фотографии не может быть пустым.";
    }

    /// <summary>
    ///     Ошибки аналитики.
    /// </summary>
    public static class Analytics
    {
        public static class PageViews
        {
            public const string NotFoundAny = "Просмотры по заданному фильтру не найдены.";
        }
    }

    /// <summary>
    ///     Ошибки оборудования.
    /// </summary>
    public static class Equipment
    {
        public static readonly string GreaterThanMaxLength =
            $"Длина названия оборудования больше максимальной длины в {DomainConstraints.Equipment.MaxLength} символ(-ов).";

        /// <summary>
        ///     Ошибки инвентарного номера.
        /// </summary>
        public static class InventoryNumber
        {
            public static readonly string GreaterThanMaxLength =
                $"Длина инвентарного номера больше максимальной длины в {DomainConstraints.Equipment.InventoryNumber.MaxLength} символ(-ов).";
        }

        /// <summary>
        ///     Ошибки типа оборудования.
        /// </summary>
        public static class Type
        {
            public static readonly string GreaterThanMaxLength =
                $"Длина названия типа оборудования больше максимальной длины в {DomainConstraints.Equipment.Type.MaxLength} символ(-ов).";
        }
    }
}