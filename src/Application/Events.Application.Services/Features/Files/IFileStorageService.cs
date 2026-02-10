using Amazon.S3.Model;

namespace Events.Application.Services.Features.Files;

/// <summary>
///     Интерфейс для файловых сервисов.
/// </summary>
public interface IFileStorageService
{
    /// <summary>
    ///     Загрузить файл в хранилище.
    /// </summary>
    /// <param name="request">Запрос на добавление.</param>
    Task PutObjectAsync(PutObjectRequest request);

    /// <summary>
    ///     Сгенерировать ссылку на скачивание файла.
    /// </summary>
    /// <param name="request">Запрос на скачивание файла.</param>
    /// <returns>
    ///     Строковое представление ссылки на скачивание.
    /// </returns>
    Task<string> GeneratePresignedUrlAsync(GetPreSignedUrlRequest request);

    /// <summary>
    ///     Удалить файл из хранилища.
    /// </summary>
    /// <param name="request">Запрос на удаление.</param>
    Task DeleteObjectAsync(DeleteObjectRequest request);
}