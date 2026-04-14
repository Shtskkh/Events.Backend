using Amazon.S3;
using Amazon.S3.Model;
using Events.Application.Services.Features.Files;
using Events.Application.Services.Shared;
using Events.Domain.Aggregates.Users;
using Events.Domain.Aggregates.Users.Errors;
using Events.Domain.Aggregates.Users.Factories;
using Events.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Events.Application.Services.Features.Users.Commands.Create;

public sealed class CreateUserHandler(
    IRepository<User> userRepository,
    IRepository<UserRole> userRoleRepository,
    IFileStorageService fileStorageService)
    : IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        Guid? avatarFilename = null;
        var dto = request.Dto;

        try
        {
            avatarFilename = await UploadAvatarAsync(dto.Avatar, cancellationToken);

            var userRole = await userRoleRepository.GetByIdAsync(UserRole.User.Id, cancellationToken);

            if (userRole == null)
                throw new NotFoundException(UserErrorMessages.Role.RoleNotFoundById(UserRole.User.Id));

            var user = UserFactory.Create(
                dto.LastName,
                dto.FirstName,
                dto.Email,
                dto.Password,
                userRole,
                avatarFilename.ToString(),
                dto.Patronymic
            );

            await userRepository.AddAsync(user, cancellationToken);

            return user.Id;
        }
        catch
        {
            if (avatarFilename.HasValue)
                await fileStorageService.SafeDeleteObjectsAsync(
                    S3Buckets.UsersAvatars,
                    [avatarFilename.Value.ToString()],
                    cancellationToken);

            throw;
        }
    }

    private async Task<Guid?> UploadAvatarAsync(IFormFile? avatar, CancellationToken cancellationToken)
    {
        if (avatar == null)
            return null;

        var filename = Guid.NewGuid();
        var putRequest = new PutObjectRequest
        {
            BucketName = S3Buckets.UsersAvatars,
            Key = filename.ToString(),
            ContentType = avatar.ContentType,
            InputStream = avatar.OpenReadStream(),
            CannedACL = S3CannedACL.PublicRead
        };

        await fileStorageService.PutObjectAsync(putRequest, cancellationToken);

        return filename;
    }
}