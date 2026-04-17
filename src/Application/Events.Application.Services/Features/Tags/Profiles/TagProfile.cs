using AutoMapper;
using Events.Contracts.Tags;
using Events.Domain.Aggregates.Events;

namespace Events.Application.Services.Features.Tags.Profiles;

public sealed class TagProfile : Profile
{
    public TagProfile()
    {
        CreateMap<Tag, TagDto>();
    }
}