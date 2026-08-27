
namespace Entities;

public class ApplicationUser
{
    public int ApplicationUserId { get; set; }

    public string UserName { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;

    public List<Comment> Comments { get; set; } = new();
    public List<ThreadItem> Threads { get; set; } = new();
}
