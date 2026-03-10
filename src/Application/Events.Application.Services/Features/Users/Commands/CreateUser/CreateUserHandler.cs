using Amazon.S3;
using Amazon.S3.Model;
using Events.Application.Services.Features.Files;
using Events.Application.Services.Features.Users.Repositories;
using Events.Domain.Aggregates.UserAggregate;
using Events.Domain.Aggregates.UserAggregate.Factories;
using MediatR;

namespace Events.Application.Services.Features.Users.Commands.CreateUser;

/// <inheritdoc />
public class CreateUserHandler(
    IUserRepository userRepository,
    IUserRoleRepository userRoleRepository,
    IFileStorageService fileStorageService)
    : IRequestHandler<CreateUserCommand, Guid>
{
    /// <inheritdoc />
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        Guid? avatarFilename = null;
        var dto = request.Dto;

        try
        {
            if (dto.Avatar != null)
            {
                avatarFilename = Guid.NewGuid();
                var putRequest = new PutObjectRequest
                {
                    BucketName = S3Buckets.UsersAvatars,
                    Key = avatarFilename.ToString(),
                    ContentType = dto.Avatar.ContentType,
                    InputStream = dto.Avatar.OpenReadStream(),
                    CannedACL = S3CannedACL.PublicRead
                };

                await fileStorageService.PutObjectAsync(putRequest);
            }

            var userRole = await userRoleRepository.GetById(UserRole.User.Id);

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
            {
                var deleteRequest = new DeleteObjectRequest
                {
                    BucketName = S3Buckets.UsersAvatars,
                    Key = avatarFilename.ToString()
                };

                await fileStorageService.DeleteObjectAsync(deleteRequest);
            }

            throw;
        }
    }
}