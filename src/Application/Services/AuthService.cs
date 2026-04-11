using Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;

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

public class UserService
{
    private List<ApplicationUser> users = new();

    public  ApplicationUser? CreateUser(string username, string password)
    {
        if (users.Any(u => u.UserName == username))
            return null;

        var user = new ApplicationUser()
        {
            ApplicationUserId = users.Count + 1,
            UserName = username,
            Password = password
        };

        users.Add(user);

        return user;
    }

    public ApplicationUser? Login(string username, string password)
    {
        return users.FirstOrDefault(
            u => u.UserName == username &&
                 u.Password == password
        );
    }
}