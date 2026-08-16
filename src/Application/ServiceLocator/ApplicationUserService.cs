
using Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace Application.ServiceLocator;


public class ApplicationUserService(ApplicationDbContext dbContext)
{
    private readonly PasswordHasher<ApplicationUser> _hasher = new();

    public List<ApplicationUser> GetAllUsers()
    {
        return dbContext.ApplicationUsers.ToList();
    }
    //
    public ApplicationUser? GetUserById(int id)
    {
        return dbContext.ApplicationUsers.FirstOrDefault(u => u.ApplicationUserId == id);
    }
    //

    public ApplicationUser CreateUser(string username, string password)
    {
        var user = new ApplicationUser
        {
            UserName = username
        };
        user.PasswordHash = _hasher.HashPassword(user, password);

        dbContext.Add(user);
        dbContext.SaveChanges();

        return user;
    }

    public void DeleteAuthor(ApplicationUser user)
    {
        Console.WriteLine(user.UserName);
        dbContext.Remove(user);
        dbContext.SaveChanges();
    }
}