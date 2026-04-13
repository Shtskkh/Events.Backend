using AutoMapper;
using Events.Application.Services.Features.Users.Specifications;
using Events.Application.Services.Shared;
using Events.Contracts.Users;
using Events.Domain.Aggregates.Users;
using MediatR;

namespace Events.Application.Services.Features.Users.Queries.GetById;

public sealed class GetUserByIdHandler(IRepository<User> userRepository, IMapper mapper)
    : IRequestHandler<GetUserByIdQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var spec = new UserSpec().WithId(request.Id).AsNoTracking();
        var user = await userRepository.FirstOrDefaultAsync(spec, cancellationToken);

        return mapper.Map<UserDto>(user);
    }
}