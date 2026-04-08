using Events.Domain.Aggregates.LocationAggregate.Constraints;

namespace Events.Domain.Aggregates.LocationAggregate.Errors;

/// <summary>
///     Ошибки помещений.
/// </summary>
public static class PlaceErrorMessages
{
    public const string NotFoundAny = "Помещения не найдены.";
    public const string NotFound = "Помещение не найдено.";

    /// <summary>
    ///     Ошибки названия помещения.
    /// </summary>
    public static class Title
    {
        public static readonly string GreaterThanMaxLength =
            $"Название помещения больше максимальной длины в {PlaceConstraints.Title.MaxLength} символ(-ов).";
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
            $"Номер помещения больше максимальной длины в {PlaceConstraints.Number.MaxLength} символ(-ов).";
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
            $"Название типа помещения больше максимальной длины в {PlaceConstraints.Type.MaxLength} символ(-ов).";
    }
}