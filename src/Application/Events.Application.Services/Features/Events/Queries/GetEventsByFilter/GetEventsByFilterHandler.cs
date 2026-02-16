using Amazon.S3;
using Amazon.S3.Model;
using AutoMapper;
using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Events.Specifications;
using Events.Application.Services.Features.Files;
using Events.Contracts.Features.Events.DTOs;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetEventsByFilter;

/// <summary>
///     Handler для получения мероприятий по фильтрам.
/// </summary>
/// <param name="repository">Репозиторий мероприятий.</param>
/// <param name="mapper">Маппер.</param>
public class GetEventsByFilterHandler(IEventRepository repository, IFileStorageService storageService, IMapper mapper)
    : IRequestHandler<GetEventsByFilterQuery, IReadOnlyCollection<ShortEventDto>>
{
    /// <summary>
    ///     Исполнить запрос.
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Иммутабельный список мероприятий.</returns>
    public async Task<IReadOnlyCollection<ShortEventDto>> Handle(GetEventsByFilterQuery request,
        CancellationToken cancellationToken)
    {
        var spec = new EventFilterSpecification(request.filter);
        var events = await repository.GetByFilterAsync(spec);

        var dtos = mapper.Map<List<ShortEventDto>>(events);

        var urlTasks = events.Select(async (e, index) =>
        {
            var key = e.PreviewFilename == null ? e.PlaceholderFilename : e.PreviewFilename.ToString();
            var bucket = e.PreviewFilename == null ? S3Buckets.EventsPlaceholders : S3Buckets.EventsPreviews;

            var downloadPreviewRequest = new GetPreSignedUrlRequest
            {
                BucketName = bucket,
                Key = key,
                Expires = DateTime.Now.AddMinutes(5),
                Protocol = Protocol.HTTP
            };

            var url = await storageService.GeneratePresignedUrlAsync(downloadPreviewRequest);

            dtos[index].PreviewDownloadLink = new Uri(url);
        });

        await Task.WhenAll(urlTasks);

        return dtos.AsReadOnly();
    }
}