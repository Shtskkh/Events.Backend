using Events.Contracts.Users;
using MediatR;

namespace Events.Application.Services.Features.Users.Queries.GetById;

public sealed record GetUserByIdQuery(Guid Id) : IRequest<UserDto>;