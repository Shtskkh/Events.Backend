using Events.Application.Services.Features.Users.Repositories;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.Errors;
using MediatR;

namespace Events.Application.Services.Features.Users.Commands.ChangePassword;

public class ChangePasswordHandler(IUserRepository userRepository) : IRequestHandler<ChangePasswordCommand>
{
    public async Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetById(request.UserId, cancellationToken);

        if (user.Password.Value != request.Dto.OldPassword)
            throw new DomainException(PasswordErrorMessages.OldPasswordDoesNotMatch);

        user.ChangePassword(request.Dto.NewPassword);

        await userRepository.UpdateAsync(user, cancellationToken);
    }
}