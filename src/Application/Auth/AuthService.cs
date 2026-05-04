using Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Auth;

// public class AuthService: IAuthService
// {
//     // private readonly SignInManager<ApplicationUser> _signInManager;
//     private readonly UserManager<ApplicationUser> _userManager;
//
//     public AuthService(UserManager<ApplicationUser> userManager)
//     {
//         _userManager = userManager;
//     }
//     
//     public Task<bool> Login(string username)
//     {
//         throw new NotImplementedException();
//     }
// }
//
// public interface IAuthService
// {
//     Task<bool> Login(string username);  
// }
//

public class AuthService
{
    private ApplicationUser? _currentUser;
    public ApplicationUser? CurrentUser => _currentUser;
    
    private readonly ApplicationDbContext _dbContext;
    public AuthService(ApplicationDbContext _dbContext)
    {
        this._dbContext = _dbContext;
    }

    public async Task<bool> Login(string username) //, string password)
    {
        var user = await _dbContext.ApplicationUsers
           .FirstOrDefaultAsync(u => u.UserName == username);
        
        if (user == null) return false;
        
        _currentUser = user;
        return true;
    }

    public void Logout()
    {
        _currentUser = null;
    }

    // private bool VerifyPassword(string password, string hash)
    // {
    //     return BCrypt.Net.BCrypt.Verify(password, hash);
    // }
}