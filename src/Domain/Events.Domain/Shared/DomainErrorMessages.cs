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
        /// <summary>
        ///     Строка текста пустая или состоит из пробелов.
        /// </summary>
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
            /// <summary>
            ///     Длина названия мероприятия меньше минимальной длины.
            /// </summary>
            public const string LessThanMinLenght = "Название мероприятия меньше минимальной длины.";

            /// <summary>
            ///     Длина названия мероприятия больше максимальной длины.
            /// </summary>
            public const string GreaterThanMaxLength = "Название мероприятия больше максимальной длины.";
        }

        /// <summary>
        ///     Ошибки анонса мероприятия.
        /// </summary>
        public static class Announcement
        {
            /// <summary>
            ///     Длина анонса мероприятия меньше минимальной длины.
            /// </summary>
            public const string LessThanMinLenght = "Анонс мероприятия меньше минимальной длины.";

            /// <summary>
            ///     Длина анонса мероприятия больше максимальной длины.
            /// </summary>
            public const string GreaterThanMaxLength = "Анонс мероприятия больше максимальной длины.";
        }

        /// <summary>
        ///     Ошибки описания мероприятия.
        /// </summary>
        public static class Description
        {
            /// <summary>
            ///     Длина описания мероприятия меньше минимальной длины.
            /// </summary>
            public const string LessThanMinLenght = "Описание мероприятия меньше минимальной длины.";

            /// <summary>
            ///     Длина описания мероприятия больше максимальной длины.
            /// </summary>
            public const string GreaterThanMaxLength = "Описание мероприятия больше максимальной длины.";
        }

        /// <summary>
        ///     Ошибки временного промежутка мероприятия.
        /// </summary>
        public static class DateTimeRange
        {
            /// <summary>
            ///     Дата и время начала мероприятия не может быть равно или позднее дате и времени окончания.
            /// </summary>
            public const string StartLaterThanEnd =
                "Дата и время начала мероприятия не может быть равно или позднее дате и времени окончания";

            /// <summary>
            ///     Продолжительность мероприятия больше максимального количества в днях.
            /// </summary>
            public const string DurationGreaterThanMax = "Длина мероприятия больше максимальной длины.";
        }

        /// <summary>
        ///     Ошибки типа мероприятия.
        /// </summary>
        public static class Type
        {
            /// <summary>
            ///     Длина описания мероприятия меньше минимальной длины.
            /// </summary>
            public const string LessThanMinLenght = "Название типа мероприятия меньше минимальной длины.";

            /// <summary>
            ///     Длина описания мероприятия меньше минимальной длины.
            /// </summary>
            public const string GreaterThanMaxLenght = "Название типа мероприятия больше максимальной длины.";
        }

        /// <summary>
        ///     Ошибки превью мероприятия.
        /// </summary>
        public static class Preview
        {
            /// <summary>
            ///     Указаны одновременно превью и плейсхолдер.
            /// </summary>
            public const string PlaceholderAndPreviewCannotBothBeSet =
                "Нельзя указать одновременно превью и плейсхолдер.";

            /// <summary>
            ///     Не указаны ни превью, ни плейсхолдер.
            /// </summary>
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
            /// <summary>
            ///     Длина названия локации меньше минимальной.
            /// </summary>
            public static readonly string LessThanMinLength =
                $"Название локации меньше минимальной длины в {DomainConstraints.Location.Title.MinLength} символ(-ов).";

            /// <summary>
            ///     Длина названия локации больше максимальной.
            /// </summary>
            public static readonly string GreaterThanMaxLength =
                $"Название локации больше максимальной длины в {DomainConstraints.Location.Title.MaxLength} символ(-ов).";
        }

        /// <summary>
        ///     Ошибки адреса локации.
        /// </summary>
        public static class Address
        {
            /// <summary>
            ///     Длина адреса меньше минимальной.
            /// </summary>
            public static readonly string LessThanMinLength =
                $"Адрес локации меньше минимальной длины в {DomainConstraints.Location.Address.MinLength} символ(-ов).";

            /// <summary>
            ///     Длина адреса больше максимальной.
            /// </summary>
            public static readonly string GreaterThanMaxLength =
                $"Адрес локации больше максимальной длины в {DomainConstraints.Location.Address.MaxLength} символ(-ов).";
        }
    }

    /// <summary>
    ///     Ошибки помещений.
    /// </summary>
    public static class Place
    {
        /// <summary>
        ///     Помещение не найдено.
        /// </summary>
        public const string NotFound = "Помещение не найдено.";

        /// <summary>
        ///     Ошибки названия помещения.
        /// </summary>
        public static class Title
        {
            /// <summary>
            ///     Длина названия меньше минимальной.
            /// </summary>
            public static readonly string LessThanMinLength =
                $"Название локации меньше минимальной длины в {DomainConstraints.Place.Title.MinLength} символ(-ов).";

            /// <summary>
            ///     Длина названия больше максимальной.
            /// </summary>
            public static readonly string GreaterThanMaxLength =
                $"Название помещения больше максимальной длины в {DomainConstraints.Place.Title.MaxLength} символ(-ов).";
        }

        /// <summary>
        ///     Ошибки номера помещения.
        /// </summary>
        public static class Number
        {
            /// <summary>
            ///     Номер содержит минус.
            /// </summary>
            public const string ContainsMinus =
                "Номер помещения не может быть отрицательным.";

            /// <summary>
            ///     Помещение с таким номером уже существует.
            /// </summary>
            public const string AlreadyExists = "Помещение с таким номером в данной локации уже существует.";

            /// <summary>
            ///     Длина номера меньше минимальной.
            /// </summary>
            public static readonly string LessThanMinLength =
                $"Номер помещения меньше минимальной длины в {DomainConstraints.Place.Number.MinLength} символ(-ов).";

            /// <summary>
            ///     Длина номера больше максимальной.
            /// </summary>
            public static readonly string GreaterThanMaxLength =
                $"Номер помещения больше максимальной длины в {DomainConstraints.Place.Number.MaxLength} символ(-ов).";
        }

        /// <summary>
        ///     Ошибки вместимости.
        /// </summary>
        public static class Capacity
        {
            /// <summary>
            ///     Вместимость меньше или равна нулю.
            /// </summary>
            public const string CapacityLessOrEqualZero = "Вместимость помещения не может быть меньше или равна 0";
        }

        /// <summary>
        ///     Ошибки типа помещения.
        /// </summary>
        public static class Type
        {
            /// <summary>
            ///     Длина названия типа меньше минимальной.
            /// </summary>
            public static readonly string LessThanMinLength =
                $"Название типа помещения меньше минимальной длины в {DomainConstraints.Place.Type.MinLength} символ(-ов).";

            /// <summary>
            ///     Длина номера больше максимальной.
            /// </summary>
            public static readonly string GreaterThanMaxLength =
                $"Название типа помещения больше максимальной длины в {DomainConstraints.Place.Type.MaxLength} символ(-ов).";
        }
    }

    /// <summary>
    ///     Ошибки пользователей.
    /// </summary>
    public static class User
    {
        /// <summary>
        ///     Роль уже присвоена.
        /// </summary>
        public const string RoleAlreadyAssigned = "Роль уже присвоена.";

        /// <summary>
        ///     Почтовый адрес уже используется.
        /// </summary>
        public const string EmailAlreadyInUse = "Почтовый адрес уже используется.";

        /// <summary>
        ///     Ошибки ролей пользователей.
        /// </summary>
        public static class Role
        {
            /// <summary>
            ///     Длина названия роли больше максимальной.
            /// </summary>
            public static readonly string GreaterThanMaxLength =
                $"Название роли пользователя больше максимальной длины в {DomainConstraints.User.Role.MaxLength} символ(-ов).";
        }

        /// <summary>
        ///     Ошибки ФИО пользователя.
        /// </summary>
        public static class PersonName
        {
            /// <summary>
            ///     Имя больше максимальной длины.
            /// </summary>
            public static readonly string FirstNameGreaterThanMaxLength =
                $"Имя больше максимальной длины в {DomainConstraints.User.PersonName.MaxLength} символ(-ов).";

            /// <summary>
            ///     Фамилия больше максимальной длины.
            /// </summary>
            public static readonly string LastNameGreaterThanMaxLength =
                $"Фамилия больше максимальной длины в {DomainConstraints.User.PersonName.MaxLength} символ(-ов).";

            /// <summary>
            ///     Отчество большей максимальной длины.
            /// </summary>
            public static readonly string PatronymicGreaterThanMaxLength =
                $"Отчество больше максимальной длины в {DomainConstraints.User.PersonName.MaxLength} символ(-ов).";
        }
    }

    /// <summary>
    ///     Ошибки почтового адреса.
    /// </summary>
    public static class Email
    {
        /// <summary>
        ///     Неверный формат.
        /// </summary>
        public const string Invalid = "Неверный формат почтового адреса.";

        /// <summary>
        ///     Длина почтового адреса большей максимальной.
        /// </summary>
        public static readonly string GreaterThanMaxLength =
            $"Длина почтового адреса больше максимальной длины в {DomainConstraints.Email.MaxLength} символ(-ов).";
    }

    /// <summary>
    ///     Ошибки паролей.
    /// </summary>
    public static class Password
    {
        /// <summary>
        ///     Пароль содержит недопустимые символы.
        /// </summary>
        public static readonly string Invalid =
            $"Пароль не может содержать следующие символы: " +
            $"{string.Join(", ", DomainConstraints.Password.InvalidCharacters.Select(FormatChar))}.";

        /// <summary>
        ///     Длина пароля меньше минимальной.
        /// </summary>
        public static readonly string LessThanMinLength =
            $"Длина пароля меньше минимальной длины в {DomainConstraints.Password.MinLength} символ(-ов).";

        /// <summary>
        ///     Длина пароля большей максимальной.
        /// </summary>
        public static readonly string GreaterThanMaxLength =
            $"Длина пароля больше максимальной длины в {DomainConstraints.Password.MaxLength} символ(-ов).";

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
}