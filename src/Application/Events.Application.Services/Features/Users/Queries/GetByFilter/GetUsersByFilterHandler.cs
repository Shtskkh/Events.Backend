using AutoMapper;
using Events.Application.Services.Features.Users.Specifications;
using Events.Application.Services.Shared;
using Events.Contracts.Users;
using Events.Domain.Aggregates.Users;
using Events.Domain.Aggregates.Users.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Users.Queries.GetByFilter;

public sealed class GetUsersByFilterHandler(IRepository<User> userRepository, IMapper mapper)
    : IRequestHandler<GetUsersByFilter, IReadOnlyCollection<ShortUserDto>>
{
    public async Task<IReadOnlyCollection<ShortUserDto>> Handle(GetUsersByFilter request,
        CancellationToken cancellationToken)
    {
        var userFilterSpec = new UserFilterSpec(request.Filter);
        var users = await userRepository.ListAsync(userFilterSpec, cancellationToken);

        if (users.Count == 0)
            throw new NotFoundException(UserErrors.NotFoundByFilter);

        return mapper.Map<List<ShortUserDto>>(users);
    }
}