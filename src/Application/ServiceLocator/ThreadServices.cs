using Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.ServiceLocator;

public class ThreadServices
{
    ApplicationDbContext _dbContext;

    public ThreadServices(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    } 
    
    public List<ThreadItem> GetAllThreads()
    {
        return _dbContext.ThreadItems
            .Include(t => t.ApplicationUser)
            .Include(t => t.Comments)
                .ThenInclude(c => c.ApplicationUser)
            .ToList();
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

    public async Task<ThreadItem> UpdateThreadAsync(int threadId, string title, string content, ApplicationUser requestingUser)
    {
        var thread = await _dbContext.ThreadItems
            .Include(t => t.ApplicationUser)
            .FirstOrDefaultAsync(t => t.ThreadId == threadId);

        if (thread is null)
            throw new KeyNotFoundException("Null");

        EnsureOwnerOrAdmin(thread.ApplicationUser, requestingUser);

        thread.ThreadContent = content.Trim();
        thread.Title = title.Trim();
        

        ValidateThread(thread);

        await _dbContext.SaveChangesAsync();
        return thread;
    }

    public async Task DeleteThreadAsync(int threadId, ApplicationUser requestingUser)
    {
        var thread = await _dbContext.ThreadItems
            .Include(t => t.ApplicationUser)
            .FirstOrDefaultAsync(t => t.ThreadId == threadId);

        if (thread is null)
            throw new KeyNotFoundException("Nope");

        EnsureOwnerOrAdmin(thread.ApplicationUser, requestingUser);

        _dbContext.ThreadItems.Remove(thread);
        await _dbContext.SaveChangesAsync();
    }

    private static void EnsureOwnerOrAdmin(ApplicationUser owner, ApplicationUser requestingUser)
    {
        var isOwner = owner.ApplicationUserId == requestingUser.ApplicationUserId;
        var isAdmin = requestingUser.Role == "Admin";

        if (!isOwner && !isAdmin)
            throw new UnauthorizedAccessException("Inte din tråd");
    }

    public async Task<Comment> UpdateCommentAsync(int commentId,string content, ApplicationUser requestingUser)
    {
        var comment = await _dbContext.Comments
            .Include(c => c.ApplicationUser)
            .FirstOrDefaultAsync(c => c.CommentId == commentId);

        if (comment is null)
            throw new KeyNotFoundException("Kommentaren hittades inte.");

        EnsureOwnerOrAdmin(comment.ApplicationUser, requestingUser);


        comment.Content = content.Trim();
        comment.UpdatedAt = DateTime.Now;

        ValidateComment(comment);

        await _dbContext.SaveChangesAsync();
        return comment;
    }

    public async Task DeleteCommentAsync(int commentId, ApplicationUser requestingUser)
    {
        var comment = await _dbContext.Comments
            .Include(c => c.ApplicationUser)
            .FirstOrDefaultAsync(c => c.CommentId == commentId);

        if (comment is null)
            throw new KeyNotFoundException("NO kommentar.");

        EnsureOwnerOrAdmin(comment.ApplicationUser, requestingUser);

        await DeleteCommentWithRepliesAsync(commentId);
        await _dbContext.SaveChangesAsync();
    }

    private async Task DeleteCommentWithRepliesAsync(int commentId)
    {
        var replyIds = await _dbContext.Comments
            .Where(c => c.ParentCommentId == commentId)
            .Select(c => c.CommentId)
            .ToListAsync();

        foreach (var replyId in replyIds)
        {
            await DeleteCommentWithRepliesAsync(replyId);
        }

        var comment = await _dbContext.Comments.FindAsync(commentId);
        if (comment is not null)
        {
            _dbContext.Comments.Remove(comment);
        }
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

     
    }
}