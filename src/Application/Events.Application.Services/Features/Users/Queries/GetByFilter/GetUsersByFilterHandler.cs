using AutoMapper;
using Events.Application.Services.Features.Users.Repositories;
using Events.Application.Services.Features.Users.Specifications;
using Events.Contracts.Users;
using MediatR;

namespace Events.Application.Services.Features.Users.Queries.GetByFilter;

/// <inheritdoc />
public class GetUsersByFilterHandler(IUserRepository userRepository, IMapper mapper)
    : IRequestHandler<GetUsersByFilter, IReadOnlyCollection<ShortUserDto>>
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<ShortUserDto>> Handle(GetUsersByFilter request,
        CancellationToken cancellationToken)
    {
        var spec = new UserFilterSpec(request.Filter);
        var users = await userRepository.GetByFilterAsync(spec, cancellationToken);
        var dtoList = mapper.Map<List<ShortUserDto>>(users);

        return dtoList;
    }
}