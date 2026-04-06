using Events.Application.Services.Features.Users.Repositories;
using Events.Application.Services.Features.Users.Specifications;
using Events.Domain.Exceptions;
using Events.Domain.Shared.Errors;
using MediatR;

namespace Events.Application.Services.Features.Users.Commands.ChangePassword;

public sealed class ChangePasswordHandler(IUserRepository userRepository) : IRequestHandler<ChangePasswordCommand>
{
    public async Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var spec = new UserSpec().WithId(request.UserId);
        var user = await userRepository.GetAsync(spec, cancellationToken);

        if (user.Password.Value != request.Dto.OldPassword)
            throw new DomainException(PasswordErrorMessages.OldPasswordDoesNotMatch);

        user.ChangePassword(request.Dto.NewPassword);

        await userRepository.UpdateAsync(user, cancellationToken);
    }
}