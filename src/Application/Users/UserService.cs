using Entities;
using Infrastructure.Persistence;

namespace Application.Users;

public class UserService
{
    // private List<ApplicationUser> users = new();
    
    ApplicationDbContext _dbContext;
    public UserService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
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

    // public ApplicationUser? Login(string username, string password)
    // {
    //     return _dbContext.FirstOrDefault(
    //         u => u.UserName == username &&
    //              u.Password == password
    //     );
    // }
}

