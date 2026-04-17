using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Events;

/// <summary>
///     Тэг.
/// </summary>
public sealed class Tag : Entity<int>
{
    public const int MaxLength = 32;

    private Tag()
    {
    }

    public Tag(string value)
    {
        var text = new Text(value).Value;

        if (text.Length > MaxLength)
            throw new DomainException(TagErrors.GreaterThanMaxLength);

        if (text.Contains(' '))
            throw new DomainException(TagErrors.ContainsWhiteSpace);

        Value = text;
    }

    public string Value { get; } = null!;
}