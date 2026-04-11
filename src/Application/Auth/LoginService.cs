using Entities;
using Infrastructure.ApplicationDbContext;

namespace Application.Services;

public class LoginService
{
    readonly ApplicationDbContext dbContext;
    ApplicationUser? applicationUser;
    
    public LoginService(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
}
