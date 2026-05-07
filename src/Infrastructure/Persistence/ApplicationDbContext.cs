using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistence;

public class  ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions< ApplicationDbContext> options)
        : base(options) { }
    public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
    public DbSet<ThreadItem> ThreadItems => Set<ThreadItem>();
    public DbSet<Comment> Comments => Set<Comment>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User
        modelBuilder.Entity<ApplicationUser>()
            .HasKey(u => u.ApplicationUserId);

        modelBuilder.Entity<ApplicationUser>()
            .HasIndex(u => u.UserName)
            .IsUnique();

        // Thread
        modelBuilder.Entity<ThreadItem>()
            .HasKey(t => t.ThreadId);

        modelBuilder.Entity<ThreadItem>()
            .HasOne(t => t.Author)
            .WithMany(u => u.Threads)
            .HasForeignKey(t => t.AuthorId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        // Comment
        modelBuilder.Entity<Comment>()
            .HasKey(c => c.CommentId);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Author)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.AuthorId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.ThreadItem)
            .WithMany(t => t.Comments)
            .HasForeignKey(c => c.ThreadItemId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}