using Events.Domain.Aggregates.Locations.Constraints;

namespace Events.Domain.Aggregates.Locations.Errors;

/// <summary>
///     Ошибки локаций.
/// </summary>
public static class LocationErrorMessages
{
    public const string NotFoundAny = "Локации не найдены.";

    public static string NotFoundById(int locationId)
    {
        return $"Локация с ID: {locationId} не найдена.";
    }

    /// <summary>
    ///     Ошибки названия локации.
    /// </summary>
    public static class Title
    {
        public static readonly string GreaterThanMaxLength =
            $"Название локации больше максимальной длины в {LocationConstraints.Title.MaxLength} символ(-ов).";
    }

    /// <summary>
    ///     Ошибки адреса локации.
    /// </summary>
    public static class Address
    {
        public static readonly string GreaterThanMaxLength =
            $"Адрес локации больше максимальной длины в {LocationConstraints.Address.MaxLength} символ(-ов).";
    }
}