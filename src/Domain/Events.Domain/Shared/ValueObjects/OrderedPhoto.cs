using Events.Domain.Exceptions;
using Events.Domain.Shared.Errors;

namespace Events.Domain.Shared.ValueObjects;

/// <summary>
///     Упорядоченная фотография.
/// </summary>
public class OrderedPhoto : ValueObject
{
    private OrderedPhoto()
    {
    }

    /// <summary>
    ///     Конструктор.
    /// </summary>
    /// <param name="filename">Название файла.</param>
    /// <param name="order">Порядок отображения.</param>
    /// <exception cref="DomainException">Ошибка правил домена.</exception>
    public OrderedPhoto(string filename, int order)
    {
        if (string.IsNullOrWhiteSpace(filename))
            throw new DomainException(PhotoErrorMessages.FileNameNullOrWhiteSpace);

        if (order < 0)
            throw new DomainException(PhotoErrorMessages.InvalidOrder);

        Filename = filename;
        Order = order;
    }

    /// <summary>
    ///     Название файла.
    /// </summary>
    public string Filename { get; } = null!;

    /// <summary>
    ///     Порядок отображения.
    /// </summary>
    public int Order { get; }

    /// <inheritdoc />
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Filename;
    }
}