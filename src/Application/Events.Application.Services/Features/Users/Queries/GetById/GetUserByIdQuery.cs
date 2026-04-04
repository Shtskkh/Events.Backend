using Events.Contracts.Users;
using MediatR;

namespace Events.Application.Services.Features.Users.Queries.GetById;

/// <inheritdoc />
public sealed record GetUserByIdQuery(Guid Id) : IRequest<UserDto>;