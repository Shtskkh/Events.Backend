using AutoMapper;
using Events.Application.Services.Features.Users.Specifications;
using Events.Application.Services.Shared;
using Events.Contracts.Users;
using Events.Domain.Aggregates.Users;
using Events.Domain.Aggregates.Users.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Users.Queries.GetById;

public sealed class GetUserByIdHandler(IRepository<User> userRepository, IMapper mapper)
    : IRequestHandler<GetUserByIdQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var userByIdSpec = new UserByIdSpec(request.Id).AsNoTracking();
        var user = await userRepository.FirstOrDefaultAsync(userByIdSpec, cancellationToken);

        if (user == null)
            throw new NotFoundException(UserErrorMessages.UserNotFoundById(request.Id));

        return mapper.Map<UserDto>(user);
    }
}