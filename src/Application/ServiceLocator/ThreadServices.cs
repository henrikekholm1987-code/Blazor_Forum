using Entities;
using Infrastructure.Persistence;

namespace Application.ServiceLocator;

public class ThreadServices
{
    ApplicationDbContext _dbContext;
    
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
    
    
    
}