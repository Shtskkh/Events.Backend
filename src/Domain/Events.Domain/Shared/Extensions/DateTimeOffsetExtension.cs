namespace Events.Domain.Shared.Extensions;

public static class DateTimeOffsetExtension
{
    extension(DateTimeOffset)
    {
        /// <summary>
        /// Получить UTC время с офсетом сервера.
        /// </summary>
        /// <returns>UTC время с офсетом сервера.</returns>
        public static DateTimeOffset UtcNowWithServerOffset()
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
}