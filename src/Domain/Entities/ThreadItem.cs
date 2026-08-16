namespace Entities;

public class ThreadItem
{
    public int ThreadId { get; set; }
    public string Title { get; set; } = "";
    public string ThreadContent { get; set; } = "";
    public DateTime CreatedAt { get; set; }

    // public int AuthorId { get; set; }
    public ApplicationUser ApplicationUser { get; set; } = null!;
    public List<Comment>? Comments { get; set; } = new();
}

