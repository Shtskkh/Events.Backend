using Events.Domain.Aggregates.LocationAggregate.Constraints;

namespace Events.Domain.Aggregates.LocationAggregate.Errors;

/// <summary>
///     Ошибки локаций.
/// </summary>
public static class LocationErrorMessages
{
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