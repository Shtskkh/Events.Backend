namespace Events.Domain.Shared;

/// <summary>
/// Текущее дата и время с офсетом сервера.
/// </summary>
public static class CurrentDateTimeWithOffset
{
    /// <summary>
    /// Текущее дата и время с офсетом сервера.
    /// </summary>
    /// <returns> Текущее дата и время с офсетом сервера.</returns>
    public static DateTimeOffset Now()
    {
        // Текущее дата и время сервера с офсетом.
        var serverTime = DateTimeOffset.Now;

        // Дата и время в UTC формате без офсета.
        var utcTime = serverTime.ToUniversalTime();

        // UTC время c офсетом сервера.
        return new DateTimeOffset(
            utcTime.DateTime,
            serverTime.Offset
        );
    }
}