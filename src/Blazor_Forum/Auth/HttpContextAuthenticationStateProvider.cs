using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;



public class HttpContextAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly AuthenticationState _authenticationState;

    public HttpContextAuthenticationStateProvider(IHttpContextAccessor httpContextAccessor)
    {
        var user = httpContextAccessor.HttpContext?.User ?? new ClaimsPrincipal(new ClaimsIdentity());
        _authenticationState = new AuthenticationState(user);
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return Task.FromResult(_authenticationState);
    }
}