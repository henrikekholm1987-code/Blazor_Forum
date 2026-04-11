
using Microsoft.AspNetCore.Identity;

namespace Entities;

public class ThreadItem
{
    public int ThreadId { get; set; }
    public string Title { get; set; } = "";
    public string ThreadContent { get; set; } = "";
    public DateTime CreatedAt { get; set; }

    public string AuthorId { get; set; } = null!;
    public ApplicationUser Author { get; set; } = null!;
    public List<Comment> Comments { get; set; } = new();
}

public class ApplicationUser : IdentityUser
{
    public int ApplicationUserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public List<ThreadItem> Threads { get; set; } = new();
    public List<Comment> Comments { get; set; } = new();
}

public class Comment
{
    public int CommentId { get; set; }
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

    public string AuthorId { get; set; } = null!;
    public ApplicationUser Author { get; set; } = null!;

    public int ThreadItemId { get; set; }
    public ThreadItem ThreadItem { get; set; } = null!;
}