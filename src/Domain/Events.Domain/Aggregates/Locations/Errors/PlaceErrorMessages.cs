using Events.Domain.Aggregates.Locations.Constraints;

namespace Events.Domain.Aggregates.Locations.Errors;

/// <summary>
///     Ошибки помещений.
/// </summary>
public static class PlaceErrorMessages
{
    public static string NotFoundById(int placeId)
    {
        return $"Помещение с ID: {placeId} не найдено.";
    }

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

        public static string NotFoundAny => "Типы помещений не найдены.";

        public static string NotFoundById(int typeId)
        {
            return $"Тип помещения с ID: {typeId} не найдена.";
        }
    }
}