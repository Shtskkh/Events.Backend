using Events.Domain.Shared;
using Events.Domain.ValueObjects;

namespace Events.Domain.Entities;

/// <summary>
/// Внешний сервис.
/// </summary>
public class ExternalService : Entity<int>
{
    /// <summary>
    /// Наименование.
    /// </summary>
    public Title Title { get; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Id сервиса.</param>
    /// <param name="title">Наименование.</param>
    public ExternalService(int id, string title) : base(id)
    {
        Title = new Title(title);
    }
}