using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.ValueObjects;

namespace Events.Domain.Entities;

/// <summary>
/// Тэг.
/// </summary>
public class Tag : Entity<int>
{
    /// <summary>
    /// Наименование.
    /// </summary>
    public Title Title { get; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Id тэга.</param>
    /// <param name="title">Наименование.</param>
    /// <exception cref="DomainException">
    /// <see cref="DomainErrorMessages.TagErrors"/>
    /// </exception>
    public Tag(int id, string title) : base(id)
    {
        Title = new Title(title);

        if (Title.Value.Contains(' '))
        {
            throw new DomainException(DomainErrorMessages.TagErrors.TagContainsWhiteSpace);
        }

        switch (Title.Value.Length)
        {
            case < DomainConstraints.Tag.MinLength:
                throw new DomainException(DomainErrorMessages.TagErrors.TagLessThanMinLength);

            case > DomainConstraints.Tag.MaxLength:
                throw new DomainException(DomainErrorMessages.TagErrors.TagGreaterThanMaxLength);
        }
    }
}