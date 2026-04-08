

using Microsoft.EntityFrameworkCore;
    
namespace Infrastructurepwd;

public class ForumDbContext : DbContext
{
    // public DbSet<User> Users => Set<User>();
    // public DbSet<ThreadItem> Threads => Set<ThreadItem>();
    // public DbSet<Post> Posts => Set<Post>();
    
    private const string ConnectionString = "Data Source = forum_Sqlite.db";

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite(ConnectionString);

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<User>()
    //         .HasIndex(u => u.Username)
    //         .IsUnique();
    //     
    //     modelBuilder.Entity<Post>()
    //         .HasOne(p => p.Author)
    //         .WithMany(u => u.Posts)
    //         .HasForeignKey(p => p.UserId)
    //         .OnDelete(DeleteBehavior.Cascade); 
    //     
    //     modelBuilder.Entity<Comment>()
    //         .HasOne(c => c.Post)
    //         .WithMany(p => p.Comments)
    //         .HasForeignKey(c => c.PostId)
    //         .OnDelete(DeleteBehavior.Cascade); 
    //     
    //     modelBuilder.Entity<Post>()
    //         .HasIndex(p => p.CreatedAt);
    //
    //     modelBuilder.Entity<Comment>()
    //         .HasIndex(c => c.CreatedAt);
    // }
}