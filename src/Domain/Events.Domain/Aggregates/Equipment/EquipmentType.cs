using Events.Domain.Aggregates.Equipment.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Equipment;

/// <summary>
///     Тип оборудования.
/// </summary>
public class EquipmentType : Entity<int>
{
    public const int MaxTitleLength = 32;

    private EquipmentType()
    {
    }

    public EquipmentType(int id, string title) : base(id)
    {
        Title = new Text(title).Value;

        if (Title.Length > MaxTitleLength)
            throw new DomainException(EquipmentTypeErrors.TitleGreaterThanMaxLength);
    }

    public static EquipmentType Projector => new(1, "Проектор");
    public static EquipmentType Tv => new(2, "Телевизор");
    public static EquipmentType ElectronicBoard => new(3, "Электронная доска");
    public static EquipmentType Pc => new(4, "Компьютер");

    public string Title { get; } = null!;
}