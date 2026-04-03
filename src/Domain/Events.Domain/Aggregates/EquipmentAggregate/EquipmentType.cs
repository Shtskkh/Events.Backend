using Events.Domain.Aggregates.EquipmentAggregate.Constraints;
using Events.Domain.Aggregates.EquipmentAggregate.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.EquipmentAggregate;

/// <summary>
///     Тип оборудования.
/// </summary>
public class EquipmentType : Entity<int>
{
    public static readonly EquipmentType Projector = new(1, "Проектор");
    public static readonly EquipmentType Tv = new(2, "Телевизор");
    public static readonly EquipmentType ElectronicBoard = new(3, "Электронная доска");
    public static readonly EquipmentType Pc = new(4, "Компьютер");

    private EquipmentType()
    {
    }

    public EquipmentType(int id, string title) : base(id)
    {
        Title = new Text(title).Value;

        if (Title.Length > EquipmentConstraints.Type.MaxLength)
            throw new DomainException(EquipmentErrorMessages.Type.GreaterThanMaxLength);
    }

    public string Title { get; } = null!;
}