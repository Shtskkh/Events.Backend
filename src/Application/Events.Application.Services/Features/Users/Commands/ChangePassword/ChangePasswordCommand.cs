using Events.Contracts.Users;
using MediatR;

namespace Events.Application.Services.Features.Users.Commands.ChangePassword;

public sealed record ChangePasswordCommand(Guid UserId, ChangePasswordDto Dto) : IRequest;