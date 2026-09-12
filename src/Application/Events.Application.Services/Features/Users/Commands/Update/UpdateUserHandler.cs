using Amazon.S3;
using Amazon.S3.Model;
using Events.Application.Services.Features.Files;
using Events.Application.Services.Features.Users.Specifications;
using Events.Application.Services.Shared;
using Events.Domain.Aggregates.Users;
using Events.Domain.Aggregates.Users.Errors;
using Events.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Events.Application.Services.Features.Users.Commands.Update;

public sealed class UpdateUserHandler(IRepository<User> userRepository, IFileStorageService fileStorageService)
    : IRequestHandler<UpdateUserCommand>
{
    public async Task Handle(UpdateUserCommand request, CancellationToken ct)
    {
        var userByIdSpec = new UserByIdSpec(request.UserId);
        var user = await userRepository.FirstOrDefaultAsync(userByIdSpec, ct);
        if (user == null)
            throw new NotFoundException(UserErrors.NotFoundById(request.UserId));

        var dto = request.Dto;

        if (!string.IsNullOrWhiteSpace(dto.FirstName) ||
            !string.IsNullOrWhiteSpace(dto.LastName) ||
            !string.IsNullOrWhiteSpace(dto.Patronymic))
            user.ChangePersonName(dto.FirstName, dto.LastName, dto.Patronymic);

        if (dto.Avatar != null)
        {
            var fileName = await UploadNewUserAvatarAsync(dto.Avatar, ct);
            user.ChangeAvatar(fileName);
        }

        await userRepository.UpdateAsync(user, ct);
    }

    private async Task<string> UploadNewUserAvatarAsync(IFormFile avatarFile, CancellationToken ct)
    {
        var filename = Guid.NewGuid().ToString();

        await using var stream = avatarFile.OpenReadStream();
        await fileStorageService.PutObjectAsync(new PutObjectRequest
        {
            BucketName = S3Buckets.UsersAvatars,
            Key = filename,
            ContentType = avatarFile.ContentType,
            InputStream = stream,
            CannedACL = S3CannedACL.PublicRead
        }, ct);

        return filename;
    }
}