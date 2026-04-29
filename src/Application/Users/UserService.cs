using Entities;
using Infrastructure.Persistence;

namespace Application.Users;

public class UserService
{
    ApplicationDbContext _dbContext;
    public UserService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public List<ApplicationUser> GetAllUsers()
    {
        return _dbContext.ApplicationUsers.ToList();
    }

    public ApplicationUser CreateUser(string username, string password)
    {
        var user = new ApplicationUser()
        {
            UserName = username,
            Password = password
        };

        _dbContext.Add(user);
        _dbContext.SaveChanges();

        return user;
    }

    public void DeleteAuthor(ApplicationUser user)
    {
        Console.WriteLine(user.UserName);
        _dbContext.Remove(user);
        _dbContext.SaveChanges();
    }
   

    // public ApplicationUser? Login(string username, string password)
    // {
    //     return _dbContext.FirstOrDefault(
    //         u => u.UserName == username &&
    //              u.Password == password
    //     );
    // }
    
}

