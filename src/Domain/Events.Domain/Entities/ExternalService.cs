using Events.Domain.Shared;
using Events.Domain.ValueObjects;

namespace Events.Domain.Entities;

/// <summary>
/// Внешний сервис.
/// </summary>
public class ExternalService : Entity<int>
{
    /// <summary>
    /// Вконтакте.
    /// </summary>
    public static readonly ExternalService Vk = new ExternalService(1, "Вконтакте");

    /// <summary>
    /// Телеграм.
    /// </summary>
    public static readonly ExternalService Telegram = new ExternalService(2, "Телеграм");

    /// <summary>
    /// Именование внешнего сервиса.
    /// </summary>
    public Title Value { get; }

    private ExternalService(int id, string title) : base(id)
    {
        Value = new Title(title);
    }
}