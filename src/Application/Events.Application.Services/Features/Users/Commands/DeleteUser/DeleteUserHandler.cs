using Events.Application.Services.Features.Users.Repositories;
using MediatR;

namespace Events.Application.Services.Features.Users.Commands.DeleteUser;

/// <inheritdoc />
public class DeleteUserHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand>
{
    /// <inheritdoc />
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetById(request.Id, cancellationToken);
        await userRepository.DeleteAsync(user, cancellationToken);
    }
}