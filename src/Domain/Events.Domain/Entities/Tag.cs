using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.ValueObjects;

namespace Events.Domain.Entities;

/// <summary>
/// Тэг мероприятия.
/// </summary>
public class Tag : Entity<int>
{
    /// <summary>
    /// Наименование тэга.
    /// </summary>
    public Title Title { get; }

    public Tag(int id, string title) : base(id)
    {
        Title = new Title(title);

        if (Title.Value.Contains(' '))
        {
            throw new DomainException(DomainErrorMessage.TagContainsWhiteSpace);
        }
    }
}