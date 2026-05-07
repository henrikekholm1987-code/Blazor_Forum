using Entities;
using Infrastructure.Persistence;

namespace Application.ServiceLocator;

public class ApplicationUserService(ApplicationDbContext dbContext)
{
    public List<ApplicationUser> GetAllUsers()
    {
        return dbContext.ApplicationUsers.ToList();
    }

    public ApplicationUser CreateUser(string username, string password)
    {
        var user = new ApplicationUser()
        {
            UserName = username,
            PasswordHash = password
        };

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

