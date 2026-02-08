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
    /// Удалить файл из хранилища.
    /// </summary>
    /// <param name="request">Запрос на удаление.</param>
    Task DeleteObjectAsync(DeleteObjectRequest request);
}