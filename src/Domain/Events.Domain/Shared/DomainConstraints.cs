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
        /// <summary>
        /// Минимальная длина тэга.
        /// </summary>
        public const int MinLength = 2;

        /// <summary>
        /// Максимальная длина тэга.
        /// </summary>
        public const int MaxLength = 32;
    }
}