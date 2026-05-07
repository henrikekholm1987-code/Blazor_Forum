namespace Entities;

public class ThreadItem
{
    public int ThreadId { get; set; }
    public string Title { get; set; } = "";
    public string ThreadContent { get; set; } = "";
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public bool IsLocked { get; set; }
    public bool IsPinned { get; set; }
    public int AuthorId { get; set; }
    public ApplicationUser Author { get; set; } = null!;
    public List<Comment>? Comments { get; set; } = new();
    
}
