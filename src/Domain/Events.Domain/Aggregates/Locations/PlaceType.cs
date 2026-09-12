using Events.Domain.Aggregates.Locations.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Locations;

/// <summary>
///     Тип помещения.
/// </summary>
public class PlaceType : Entity<int>
{
    public const int MaxTitleLength = 16;

    public static readonly PlaceType Coworking = new(1, "Коворкинг");
    public static readonly PlaceType Conference = new(2, "Конференц-зал");
    public static readonly PlaceType Audience = new(3, "Аудитория");

    private PlaceType()
    {
    }

    public PlaceType(int id, string title) : base(id)
    {
        Title = new Text(title).Value;

        if (Title.Length > MaxTitleLength)
            throw new DomainException(PlaceTypeErrors.TitleGreaterThanMaxLength);
    }

    public string Title { get; } = null!;
}