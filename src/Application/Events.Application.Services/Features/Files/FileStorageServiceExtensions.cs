using Amazon.S3.Model;

namespace Events.Application.Services.Features.Files;

/// <summary>
///     Расширения для файлового хранилища.
/// </summary>
public static class FileStorageServiceExtensions
{
    extension(IFileStorageService fileStorageService)
    {
        /// <summary>
        ///     Удалить файлы из хранилища, подавляя исключения.
        ///     Используется как компенсирующая операция при откате.
        /// </summary>
        /// <param name="bucketName">Название bucket.</param>
        /// <param name="fileNames">Названия файлов.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        public async Task SafeDeleteObjectsAsync(string bucketName, IEnumerable<string> fileNames,
            CancellationToken cancellationToken = default)
        {
            var keys = fileNames
                .Select(f => new KeyVersion { Key = f })
                .ToList();

            if (keys.Count == 0)
                return;

            try
            {
                var request = new DeleteObjectsRequest
                {
                    BucketName = bucketName,
                    Objects = keys
                };

                await fileStorageService.DeleteObjectsAsync(request, cancellationToken);
            }
            catch
            {
                // Не маскируем оригинальное исключение
            }
        }
    }
}