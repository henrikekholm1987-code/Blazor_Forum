using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.ApplicationDbContext;

public class  ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions< ApplicationDbContext> options)
        : base(options) { }
    public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
    public DbSet<ThreadItem> ThreadItems => Set<ThreadItem>();
    public DbSet<Comment> Comments => Set<Comment>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ApplicationUser>()
            .HasIndex(u => u.UserName)
            .IsUnique();
        
        modelBuilder.Entity<ThreadItem>()
            .HasOne(t => t.Author)
            .WithMany(u => u.Threads)
            .HasForeignKey(t => t.AuthorId);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Author)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.AuthorId);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.ThreadItem)
            .WithMany(t => t.Comments)
            .HasForeignKey(c => c.ThreadItemId);

    }
}