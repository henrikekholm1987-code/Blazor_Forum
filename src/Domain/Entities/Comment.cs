namespace Entities;

public class Comment
{
    public int CommentId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public ApplicationUser ApplicationUser { get; set; } = null!;

    public ThreadItem ThreadItem { get; set; } = null!;
}
