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
        var value = new Text(title).Value;

        if (value.Length > DomainConstraints.Equipment.Type.MaxLength)
            throw new DomainException(DomainErrorMessages.Equipment.Type.GreaterThanMaxLength);

        Title = value;
    }

    public string Title { get; private set; } = null!;
}