using AutoMapper;
using Events.Application.Services.Features.Files;
using Events.Contracts.Features.Events.DTOs;
using Events.Contracts.Features.Files;
using Events.Domain.Aggregates.EventAggregate;

namespace Events.Application.Services.Features.Events.Mappings;

/// <summary>
///     Профиль маппинга для мероприятий.
/// </summary>
public class EventProfile : Profile
{
    /// <inheritdoc />
    public EventProfile()
    {
        CreateMap<Event, EventDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title,
                opt => opt.MapFrom(src => src.Title.Value))
            .ForMember(dest => dest.Description,
                opt => opt.MapFrom(src => src.Description.Value))
            .ForMember(dest => dest.Type,
                opt => opt.MapFrom(e => e.Type.Title))
            .ForMember(dest => dest.Format,
                opt => opt.MapFrom(e => e.Format.Title))
            .ForMember(dest => dest.PreviewInfo,
                opt =>
                    opt.MapFrom(src => src.PreviewFilename == null
                        ? new S3FileDto
                        {
                            Bucket = S3Buckets.EventsPlaceholders,
                            Key = src.PlaceholderFilename
                        }
                        : new S3FileDto
                        {
                            Bucket = S3Buckets.EventsPreviews,
                            Key = src.PreviewFilename
                        }));


        CreateMap<Event, ShortEventDto>()
            .ForMember(dest => dest.Title,
                opt => opt.MapFrom(src => src.Title.Value))
            .ForMember(dest => dest.Announcement,
                opt => opt.MapFrom(src => src.Announcement.Value))
            .ForMember(dest => dest.Type,
                opt => opt.MapFrom(e => e.Type.Title))
            .ForMember(dest => dest.Format,
                opt => opt.MapFrom(e => e.Format.Title))
            .ForMember(dest => dest.PreviewInfo,
                opt =>
                    opt.MapFrom(src => src.PreviewFilename == null
                        ? new S3FileDto
                        {
                            Bucket = S3Buckets.EventsPlaceholders,
                            Key = src.PlaceholderFilename
                        }
                        : new S3FileDto
                        {
                            Bucket = S3Buckets.EventsPreviews,
                            Key = src.PreviewFilename
                        }));
    }
}