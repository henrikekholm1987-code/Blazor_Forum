
using Microsoft.AspNetCore.Identity;

namespace Entities;

public class ThreadItem
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string ThreadContent { get; set; } = "";

    public DateTime CreatedAt { get; set; }

    public string UserId { get; set; } = null!;
    
    public ApplicationUser Author { get; set; } = null!;
    public List<Comment> Comments { get; set; } = new();
}

public class ApplicationUser: IdentityUser
{
    public string Id { get; set; } = null!;
    public string Username { get; set; } = null!;
    
    public List<ThreadItem> ThreadItem { get; set; } = new();
}

public class Comment
{
    public int Id { get; set; }
    public string User { get; set; } = null!;
    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int ThreadItemId { get; set; }

    public ThreadItem ThreadItem { get; set; } = null!;
}