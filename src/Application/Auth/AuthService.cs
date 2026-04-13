using Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Auth;

public class AuthService: IAuthService
{
    // private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    
    public Task<bool> Login(string username, string password)
    {
        throw new NotImplementedException();
    }
}

public interface IAuthService
{
    Task<bool> Login(string username, string password);  
}

