namespace Events.Domain.Shared;

/// <summary>
///     Record для ошибок.
/// </summary>
/// <param name="ErrorCode">Код ошибки.</param>
/// <param name="ErrorMessage">Сообщение ошибки.</param>
public record Error(string ErrorCode, string ErrorMessage);