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

    // public void AddThread(string NewThreadTitle, string NewThreadContent)
    // {
    //     ThreadItem newThread = new ThreadItem()
    //         .Title(NewThreadTitle)
    //         .Content(NewThreadContent)
    //         
    //     
    //     _dbContext.ThreadItems.Add(thread);
    // }
    
    public ThreadItem CreateThread(ThreadItem thread)
    {
        _dbContext.ThreadItems.Add(thread);
        _dbContext.SaveChanges();
        return thread;
    }
    
    
    
}