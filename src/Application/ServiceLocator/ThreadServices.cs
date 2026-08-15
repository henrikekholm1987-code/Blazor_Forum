using Entities;
using Infrastructure.Persistence;

namespace Application.ServiceLocator;

public class ThreadServices
{
    ApplicationDbContext _dbContext;

    public ThreadServices(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    string NewThreadTitle = "";
    string NewThreadContent = "";
    
    public List<ThreadItem> GetAllThreads()
    {
        return _dbContext.ThreadItems.ToList();
    }
    
    public ThreadItem CreateThread(ThreadItem thread)
    {
        _dbContext.ThreadItems.Add(thread);
        _dbContext.SaveChanges();
        return thread;
    }

    public async Task<ThreadItem> CreateThreadAsync(ThreadItem thread)
    {
        ValidateThread(thread);

        _dbContext.ThreadItems.Add(thread);
        await _dbContext.SaveChangesAsync();

        return thread;
    }

    public async Task<Comment> CreateCommentAsync(Comment comment)
    {
        ValidateComment(comment);

        _dbContext.Comments.Add(comment);
        await _dbContext.SaveChangesAsync();

        return comment;
    }

    private static void ValidateComment(Comment comment)
    {
        if (string.IsNullOrWhiteSpace(comment.Content))
            throw new ArgumentException("Kommentaren får inte vara tom.", nameof(comment.Content));

        if (comment.ApplicationUser is null)
            throw new ArgumentException("Kommentaren måste ha en författare.", nameof(comment.ApplicationUser));

        if (comment.ThreadItem is null)
            throw new ArgumentException("Kommentaren måste tillhöra en tråd.", nameof(comment.ThreadItem));
    }

    private static void ValidateThread(ThreadItem thread)
    {
        if (string.IsNullOrWhiteSpace(thread.Title))
            throw new ArgumentException("Titeln får inte vara tom.", nameof(thread.Title));

        if (thread.Title.Length > 200)
            throw new ArgumentException("Titeln är för lång (max 200 tecken).", nameof(thread.Title));

        if (string.IsNullOrWhiteSpace(thread.ThreadContent))
            throw new ArgumentException("Innehållet får inte vara tomt.", nameof(thread.ThreadContent));
    }
}