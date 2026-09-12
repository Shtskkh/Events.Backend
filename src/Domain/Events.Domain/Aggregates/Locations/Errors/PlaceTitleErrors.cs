using Events.Domain.Aggregates.Locations.ValueObjects.Places;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Locations.Errors;

public static class PlaceTitleErrors
{
    public static Error GreaterThanMaxLength => new("PlaceTitle.GreaterThanMaxLength",
        $"Название помещения больше максимальной длины в {PlaceTitle.MaxLength} символ(-ов).");
}