using Events.Application.Services.Features.Users.Repositories;
using Events.Application.Services.Features.Users.Specifications;
using MediatR;

namespace Events.Application.Services.Features.Users.Commands.Delete;

/// <inheritdoc />
public sealed class DeleteUserHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand>
{
    /// <inheritdoc />
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var spec = new UserSpec().WithId(request.Id);
        var user = await userRepository.GetAsync(spec, cancellationToken);

        await userRepository.DeleteAsync(user, cancellationToken);
    }
}