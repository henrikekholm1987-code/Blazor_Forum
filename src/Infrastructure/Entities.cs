namespace Infrastructure;


public class ThreadItem
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string ThreadContent { get; set; } = "";
    
    public DateTime CreatedAt { get; set; }

    public int UserId { get; set; }
    public User Author { get; set; } = null!;

    public List<Comment> Comments { get; set; } = new();
}

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public List<ThreadItem> ThreadItem { get; set; } = new();
}

public class Comment
{
    public string Text { get; set; }
    
    public int Id { get; set; }
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    
    public int PostId { get; set; }
    public ThreadItem ThreadItem { get; set; } = null!;
}