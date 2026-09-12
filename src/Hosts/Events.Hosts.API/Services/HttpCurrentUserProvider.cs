using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Events.Application.Services.Interfaces;

namespace Events.Hosts.API.Services;

public class HttpCurrentUserProvider(IHttpContextAccessor httpContextAccessor) : ICurrentUserProvider
{
    private ClaimsPrincipal? User => httpContextAccessor.HttpContext?.User;
    public bool IsAuthenticated => User?.Identity?.IsAuthenticated ?? false;

    public Guid? UserId => Guid.TryParse(
        User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value, out var id)
        ? id
        : null;

    public string? Role => User?.FindFirst("role")?.Value;
}