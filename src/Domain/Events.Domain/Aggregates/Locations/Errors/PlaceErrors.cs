using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Locations.Errors;

public static class PlaceErrors
{
    public static Error NotFoundById(int placeId)
    {
        return new Error("Place.NotFoundById", $"Помещение с ID: {placeId} не найдено.");
    }
}