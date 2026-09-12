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
    /// <param name="cancellationToken">Токен отмены.</param>
    Task PutObjectAsync(PutObjectRequest request, CancellationToken cancellationToken);

    /// <summary>
    ///     Получить информацию о всех объектах.
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Объект с данными о всех объектах.</returns>
    Task<ListObjectsV2Response> ListObjectsAsync(ListObjectsV2Request request, CancellationToken cancellationToken);

    /// <summary>
    ///     Получить файл.
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Объект с данными о файле.</returns>
    Task<GetObjectResponse> GetObjectAsync(GetObjectRequest request, CancellationToken cancellationToken);

    /// <summary>
    ///     Удалить файл из хранилища.
    /// </summary>
    /// <param name="request">Запрос на удаление.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task DeleteObjectAsync(DeleteObjectRequest request, CancellationToken cancellationToken);

    /// <summary>
    ///     Удалить несколько файлов из хранилища.
    /// </summary>
    /// <param name="request">Запрос на удаление.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Объект с данными об удалённых и не удалённых файлах.</returns>
    Task<DeleteObjectsResponse> DeleteObjectsAsync(DeleteObjectsRequest request, CancellationToken cancellationToken);
}