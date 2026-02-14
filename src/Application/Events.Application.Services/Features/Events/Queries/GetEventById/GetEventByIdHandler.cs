using Amazon.S3;
using Amazon.S3.Model;
using AutoMapper;
using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Files;
using Events.Contracts.Features.Events.DTOs;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetEventById;

/// <summary>
///     Handler для получения мероприятия по ID.
/// </summary>
/// <param name="eventRepository">Репозиторий мероприятий.</param>
/// <param name="mapper">Маппер.</param>
public class GetEventByIdHandler(
    IEventRepository eventRepository,
    IFileStorageService storageService,
    IMapper mapper)
    : IRequestHandler<GetEventByIdQuery, EventDto>
{
    /// <summary>
    ///     Метод исполнения запрос.
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>
    ///     DTO мероприятия.
    /// </returns>
    public async Task<EventDto> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
    {
        var @event = await eventRepository.GetByIdAsync(request.Id);

        var downloadPreviewRequest = new GetPreSignedUrlRequest
        {
            BucketName = S3Buckets.EventsPreviews,
            Key = @event.PreviewFilename.ToString(),
            Expires = DateTime.Now.AddMinutes(5),
            Protocol = Protocol.HTTP
        };

        var url = await storageService.GeneratePresignedUrlAsync(downloadPreviewRequest);

        var dto = mapper.Map<EventDto>(@event);
        dto.PreviewDownloadLink = new Uri(url);

        return dto;
    }
}