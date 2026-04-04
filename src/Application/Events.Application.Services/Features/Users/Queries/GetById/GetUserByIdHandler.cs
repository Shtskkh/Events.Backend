using AutoMapper;
using Events.Application.Services.Features.Users.Repositories;
using Events.Contracts.Users;
using MediatR;

namespace Events.Application.Services.Features.Users.Queries.GetById;

/// <inheritdoc />
public sealed class GetUserByIdHandler(IUserRepository userRepository, IMapper mapper)
    : IRequestHandler<GetUserByIdQuery, UserDto>
{
    /// <inheritdoc />
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetById(request.Id, cancellationToken);

        return mapper.Map<UserDto>(user);
    }
}