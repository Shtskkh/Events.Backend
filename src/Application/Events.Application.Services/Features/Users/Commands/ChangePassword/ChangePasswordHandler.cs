using Events.Application.Services.Shared;
using Events.Domain.Aggregates.Users;
using Events.Domain.Aggregates.Users.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared.Errors;
using MediatR;

namespace Events.Application.Services.Features.Users.Commands.ChangePassword;

public sealed class ChangePasswordHandler(IRepository<User> userRepository) : IRequestHandler<ChangePasswordCommand>
{
    public async Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user == null)
            throw new NotFoundException(UserErrors.NotFoundById(request.UserId));

        if (user.Password.Value != request.Dto.OldPassword)
            throw new DomainException(PasswordErrors.OldPasswordDoesNotMatch);

        user.ChangePassword(request.Dto.NewPassword);

        await userRepository.UpdateAsync(user, cancellationToken);
    }
}