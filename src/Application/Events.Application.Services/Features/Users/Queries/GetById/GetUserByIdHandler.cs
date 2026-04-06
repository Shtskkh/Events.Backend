using AutoMapper;
using Events.Application.Services.Features.Users.Repositories;
using Events.Application.Services.Features.Users.Specifications;
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
        var spec = new UserSpec().WithId(request.Id).AsNoTracking();
        var user = await userRepository.GetAsync(spec, cancellationToken);

        return mapper.Map<UserDto>(user);
    }
}