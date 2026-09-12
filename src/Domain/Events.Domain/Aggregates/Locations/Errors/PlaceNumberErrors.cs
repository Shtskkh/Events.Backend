using Events.Domain.Aggregates.Locations.ValueObjects.Places;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Locations.Errors;

public static class PlaceNumberErrors
{
    public static Error ContainsMinus =>
        new("PlaceNumber.ContainsMinus", "Номер помещения не может быть отрицательным.");

    public static Error GreaterThanMaxLength => new("PlaceNumber.GreaterThanMaxLength",
        $"Номер помещения больше максимальной длины в {PlaceTitle.MaxLength} символ(-ов).");

    public static Error AlreadyExists(string number)
    {
        return new Error("PlaceNumber.AlreadyExists", $"Помещение с номером {number} в данной локации уже существует.");
    }
}