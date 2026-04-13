using Entities;

namespace Application.Users;

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

