using Amazon.S3;
using Amazon.S3.Model;
using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Events.Specifications;
using Events.Application.Services.Features.Files;
using Events.Application.Services.Features.Locations.Specifications;
using Events.Application.Services.Shared;
using Events.Domain.Aggregates.Events;
using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Aggregates.Events.Factories;
using Events.Domain.Aggregates.Locations;
using Events.Domain.Aggregates.Locations.Errors;
using Events.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using EventType = Events.Domain.Aggregates.Events.EventType;

namespace Events.Application.Services.Features.Events.Commands.Create;

public sealed class CreateEventHandler(
    IEventRepository eventRepository,
    IRepository<EventType> eventTypeRepository,
    IRepository<EventFormat> eventFormatRepository,
    IRepository<Location> locationRepository,
    IFileStorageService fileStorageService)
    : IRequestHandler<CreateEventCommand, Guid>
{
    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        Guid? previewFilename = null;
        var dto = request.Dto;

        try
        {
            previewFilename = await UploadPreviewAsync(dto.Preview, cancellationToken);

            var eventType = await eventTypeRepository.GetByIdAsync(dto.EventTypeId, cancellationToken);

            if (eventType == null)
                throw new NotFoundException(EventTypeErrors.NotFoundById(dto.EventTypeId));

            var eventFormat = await eventFormatRepository.GetByIdAsync(dto.EventFormatId, cancellationToken);

            if (eventFormat == null)
                throw new NotFoundException(EventErrorMessages.Format.NotFoundById(dto.EventFormatId));

            if (eventFormat.Id != EventFormat.Online.Id)
                await ValidateBookingAsync(
                    dto.LocationId,
                    dto.PlaceId,
                    dto.StartDateTime,
                    dto.EndDateTime,
                    cancellationToken);

            var @event = EventFactory.Create(
                dto.Title,
                dto.Announcement,
                dto.Description,
                dto.StartDateTime.ToUniversalTime(),
                dto.EndDateTime.ToUniversalTime(),
                eventType,
                eventFormat,
                dto.UserId,
                dto.NeedsRegistration,
                dto.LocationId,
                dto.PlaceId,
                dto.MaxParticipants,
                previewFilename?.ToString(),
                dto.Placeholder
            );

            await eventRepository.AddAsync(@event, cancellationToken);

            return @event.Id;
        }
        catch
        {
            if (previewFilename.HasValue)
                await fileStorageService.SafeDeleteObjectsAsync(
                    S3Buckets.EventsPreviews,
                    [previewFilename.Value.ToString()],
                    cancellationToken);
            throw;
        }
    }

    private async Task<Guid?> UploadPreviewAsync(IFormFile? preview, CancellationToken cancellationToken)
    {
        if (preview == null)
            return null;

        var filename = Guid.NewGuid();
        var putRequest = new PutObjectRequest
        {
            BucketName = S3Buckets.EventsPreviews,
            Key = filename.ToString(),
            ContentType = preview.ContentType,
            InputStream = preview.OpenReadStream(),
            CannedACL = S3CannedACL.PublicRead
        };

        await fileStorageService.PutObjectAsync(putRequest, cancellationToken);

        return filename;
    }

    private async Task ValidateBookingAsync(
        int? locationId,
        int? placeId,
        DateTimeOffset start,
        DateTimeOffset end,
        CancellationToken cancellationToken)
    {
        if (!locationId.HasValue || !placeId.HasValue)
            throw new DomainException(EventErrorMessages.Booking.RequiredForOfflineAndHybrid);

        var locationByIdSpec = new LocationByIdSpec(locationId.Value).IncludePlaces().AsNoTracking();
        var location = await locationRepository.FirstOrDefaultAsync(locationByIdSpec, cancellationToken);

        if (location == null)
            throw new NotFoundException(LocationErrorMessages.NotFoundById(locationId.Value));

        var placeExists = location.Places.Any(place => place.Id == placeId.Value);

        if (!placeExists)
            throw new NotFoundException(PlaceErrorMessages.NotFoundById(placeId.Value));

        var hasConflict = await eventRepository.AnyAsync(
            new HasBookingConflictSpec(
                placeId.Value,
                start.ToUniversalTime(),
                end.ToUniversalTime()),
            cancellationToken);

        if (hasConflict)
            throw new DomainException(EventErrorMessages.Booking.TimeConflict);
    }
}