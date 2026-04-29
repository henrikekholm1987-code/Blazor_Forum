using System.Security.Claims;
using Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class LoginService
{
    readonly ApplicationDbContext _dbContext;
    readonly IHttpContextAccessor _httpContextAccessor;
    
    public LoginService(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<bool> LoginAsync(string username)
    {
        var user = await _dbContext.ApplicationUsers
            .FirstOrDefaultAsync(u => u.UserName == username);

        if (user is null) return false;

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.ApplicationUserId.ToString()),
            new(ClaimTypes.Name, user.UserName),
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await _httpContextAccessor.HttpContext!.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal);

        return true;
    }
    
    // public async Task LogoutAsync()
    // {
    //     await _httpContextAccessor.HttpContext!.SignOutAsync(
    //         CookieAuthenticationDefaults.AuthenticationScheme);
    // }
}
