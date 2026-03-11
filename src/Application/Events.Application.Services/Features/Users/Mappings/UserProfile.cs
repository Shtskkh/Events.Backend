using AutoMapper;
using Events.Application.Services.Features.Files;
using Events.Contracts.Features.Files;
using Events.Contracts.Features.Users.DTOs;
using Events.Domain.Aggregates.UserAggregate;

namespace Events.Application.Services.Features.Users.Mappings;

/// <inheritdoc />
public class UserProfile : Profile
{
    /// <inheritdoc />
    public UserProfile()
    {
        CreateMap<User, ShortUserDto>()
            .ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src => src.PersonName.FirstName))
            .ForMember(dest => dest.LastName,
                opt => opt.MapFrom(src => src.PersonName.LastName))
            .ForMember(dest => dest.Patronymic,
                opt => opt.MapFrom(src => src.PersonName.Patronymic))
            .ForMember(dest => dest.AvatarInfo,
                opt => opt.MapFrom(src => src.AvatarFilename != null
                    ? new S3FileDto
                    {
                        Bucket = S3Buckets.UsersAvatars,
                        Key = src.AvatarFilename
                    }
                    : null));

        CreateMap<User, UserDto>()
            .ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src => src.PersonName.FirstName))
            .ForMember(dest => dest.LastName,
                opt => opt.MapFrom(src => src.PersonName.LastName))
            .ForMember(dest => dest.Patronymic,
                opt => opt.MapFrom(src => src.PersonName.Patronymic))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
            .ForMember(dest => dest.AvatarInfo,
                opt => opt.MapFrom(src => src.AvatarFilename != null
                    ? new S3FileDto
                    {
                        Bucket = S3Buckets.UsersAvatars,
                        Key = src.AvatarFilename
                    }
                    : null));
    }
}