using Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.ServiceLocator;

public class ApplicationUserService(ApplicationDbContext dbContext)
{
    private readonly PasswordHasher<ApplicationUser> _hasher = new();

    public List<ApplicationUser> GetAllUsers()
    {
        return dbContext.ApplicationUsers
            .Include(u => u.Threads)
            .Include(u => u.Comments)
            .ToList();
    }

    public ApplicationUser? GetUserById(int id)
    {
        return dbContext.ApplicationUsers.FirstOrDefault(u => u.ApplicationUserId == id);
    }

    public ApplicationUser CreateUser(string username, string password, string role = "User")
    {
        var user = new ApplicationUser
        {
            UserName = username,
            Role = role,
        };
        user.PasswordHash = _hasher.HashPassword(user, password);

        dbContext.Add(user);
        dbContext.SaveChanges();

        return user;
    }

    public void SetRole(ApplicationUser user, string role)
    {
        user.Role = role;
        dbContext.SaveChanges();
    }


    public void DeleteAuthor(ApplicationUser user)
    {
        Console.WriteLine(user.UserName);
        dbContext.Remove(user);
        dbContext.SaveChanges();
    }
}