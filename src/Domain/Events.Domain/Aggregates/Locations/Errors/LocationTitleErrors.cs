using Events.Domain.Aggregates.Locations.ValueObjects.Locations;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Locations.Errors;

public static class LocationTitleErrors
{
    public static Error GreaterThanMaxLength => new("LocationTitle.GreaterThanMaxLength",
        $"Название локации больше максимальной длины в {LocationTitle.MaxLength} символ(-ов).");
}