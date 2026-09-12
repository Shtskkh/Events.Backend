namespace Events.Contracts.Files;

/// <inheritdoc />
public sealed record FileDto : IFile
{
    /// <inheritdoc />
    public Stream Content { get; set; } = null!;

    /// <inheritdoc />
    public string ContentType { get; set; } = null!;

    /// <inheritdoc />
    public string Filename { get; set; } = null!;

    /// <inheritdoc />
    public long Length { get; set; }
}