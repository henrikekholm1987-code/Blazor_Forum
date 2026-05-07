namespace Entities;

public class ApplicationUser 
{
    public int ApplicationUserId { get; set; }

    public string UserName { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;

    public List<Comment> Comments { get; set; } = new();
    public List<ThreadItem> Threads { get; set; } = new();
}


public class Comment
{
    public int CommentId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public int AuthorId { get; set; }
    public ApplicationUser Author { get; set; } = null!;

    public int ThreadItemId { get; set; }
    public ThreadItem ThreadItem { get; set; } = null!;
}
