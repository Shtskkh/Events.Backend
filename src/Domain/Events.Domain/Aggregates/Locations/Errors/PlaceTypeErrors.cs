using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Locations.Errors;

public static class PlaceTypeErrors
{
    public static Error NotFoundAny => new("PlaceType.NotFoundAny", "Типы помещений не найдены.");

    public static Error TitleGreaterThanMaxLength => new("PlaceType.GreaterThanMaxLength",
        $"Название типа помещения больше максимальной длины в {PlaceType.MaxTitleLength} символ(-ов).");

    public static Error NotFoundById(int typeId)
    {
        return new Error("PlaceType.NotFoundById", $"Тип помещения с ID: {typeId} не найден.");
    }
}