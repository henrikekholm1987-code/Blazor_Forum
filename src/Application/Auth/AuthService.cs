using Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Auth;


public class AuthService(ApplicationDbContext dbContext)
{
    private ApplicationUser? _currentUser;
    public ApplicationUser? CurrentUser => _currentUser;

    public async Task<bool> Login(string username, string password)
    {
        var normalizedUsername = username.Trim();
        var normalizedPassword = password.Trim();
        if (string.IsNullOrWhiteSpace(normalizedUsername) || string.IsNullOrWhiteSpace(normalizedPassword))
        {
            return false;
        }

        var user = await dbContext.ApplicationUsers
           .FirstOrDefaultAsync(u => u.UserName == normalizedUsername && u.PasswordHash == normalizedPassword);
        
        if (user == null) return false;
        
        _currentUser = user;
        return true;
    }

    public void Logout()
    {
        _currentUser = null;
    }
}

