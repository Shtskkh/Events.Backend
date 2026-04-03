using Events.Contracts.Files;
using MediatR;

namespace Events.Application.Services.Features.Files.Queries.GetFile;

/// <summary>
///     Запрос на получение файла из S3 хранилища.
/// </summary>
/// <param name="Bucket">Название bucket.</param>
/// <param name="Key">Название файла.</param>
public record GetFileQuery(string Bucket, string Key) : IRequest<FileDto>;