namespace Events.Domain.Shared.ValueObjects;

/// <summary>
///     Запись о фотографии при синхронизации.
/// </summary>
/// <param name="Filename">Название файла.</param>
/// <param name="IsNew">
///     Признак новой фотографии.
///     Если <c>true</c> — фото загружается впервые и не должно существовать в текущем списке.
///     Если <c>false</c> — фото уже существует и должно присутствовать в текущем списке.
/// </param>
public sealed record PhotoEntry(string Filename, bool IsNew);