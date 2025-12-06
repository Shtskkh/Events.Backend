namespace Events.Domain.Shared;

/// <summary>
/// Константы.
/// </summary>
public static class DomainConstraints
{
    /// <summary>
    /// Константы <see cref="Entities.Tag"/>
    /// </summary>
    public static class Tag
    {
        public const int MinLength = 2;
        public const int MaxLength = 32;
    }
}