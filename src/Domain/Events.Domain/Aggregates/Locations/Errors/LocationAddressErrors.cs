using Events.Domain.Aggregates.Locations.ValueObjects.Locations;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Locations.Errors;

public static class LocationAddressErrors
{
    public static Error GreaterThanMaxLength => new("LocationAddress.GreaterThanMaxLength",
        $"Адрес локации больше максимальной длины в {LocationAddress.MaxLength} символ(-ов).");
}