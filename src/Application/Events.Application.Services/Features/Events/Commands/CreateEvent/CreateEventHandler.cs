using Amazon.S3.Model;
using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Files;
using Events.Domain.Aggregates.EventAggregate.Factories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Events.Application.Services.Features.Events.Commands.CreateEvent;

/// <summary>
///     Handler для команды создания мероприятия.
/// </summary>
/// <param name="eventRepository">Репозиторий мероприятия.</param>
/// <param name="fileStorageService">Сервис хранения файлов.</param>
public class CreateEventHandler(
    IEventRepository eventRepository,
    IEventTypeRepository eventTypeRepository,
    IEventFormatRepository eventFormatRepository,
    ILogger<CreateEventHandler> logger,
    IFileStorageService fileStorageService)
    : IRequestHandler<CreateEventCommand, Guid>
{
    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var filenameGuid = Guid.NewGuid();
        var dto = request.Dto;
        try
        {
            if (dto.Preview != null)
            {
                var putRequest = new PutObjectRequest
                {
                    BucketName = S3Buckets.EventsPreviews,
                    Key = filenameGuid.ToString(),
                    ContentType = dto.Preview.ContentType,
                    InputStream = dto.Preview.OpenReadStream()
                };

                await fileStorageService.PutObjectAsync(putRequest);
            }

            var eventType = await eventTypeRepository.GetById(dto.EventTypeId);
            var eventFormat = await eventFormatRepository.GetByIdAsync(dto.EventFormatId);
            logger.LogInformation($"Created event {filenameGuid} with format {dto.EventFormatId} {eventFormat.Title}");

            var eventFactory = new EventFactory();
            var @event = eventFactory.Create(
                dto.Title,
                dto.Announcement,
                dto.Description,
                dto.StartDateTime,
                dto.EndDateTime,
                eventType,
                eventFormat,
                dto.NeedsRegistration,
                filenameGuid
            );

            await eventRepository.AddAsync(@event);

            return @event.Id;
        }
        catch
        {
            if (dto.Preview != null)
            {
                var deleteRequest = new DeleteObjectRequest
                {
                    BucketName = S3Buckets.EventsPreviews,
                    Key = filenameGuid.ToString()
                };

                await fileStorageService.DeleteObjectAsync(deleteRequest);
            }

            throw;
        }
    }
}