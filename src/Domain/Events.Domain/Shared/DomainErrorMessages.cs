namespace Events.Domain.Shared;

/// <summary>
///     Сообщения об ошибках домена.
/// </summary>
public static class DomainErrorMessages
{
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