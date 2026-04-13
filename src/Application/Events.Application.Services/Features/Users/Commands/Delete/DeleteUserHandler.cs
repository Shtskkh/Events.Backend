using Events.Application.Services.Shared;
using Events.Domain.Aggregates.Users;
using MediatR;

namespace Events.Application.Services.Features.Users.Commands.Delete;

public sealed class DeleteUserHandler(IRepository<User> userRepository) : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.Id, cancellationToken);

        await userRepository.DeleteAsync(user, cancellationToken);
    }
}