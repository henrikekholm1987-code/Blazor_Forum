using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.ApplicationDbContext;

public class  ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions< ApplicationDbContext> options)
        : base(options) { }

    public DbSet<ThreadItem> Threads => Set<ThreadItem>();
    public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
    public DbSet<ThreadItem> ThreadItems => Set<ThreadItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>()
            .HasIndex(u => u.Username)
            .IsUnique();

        modelBuilder.Entity<Comment>()
            .HasIndex(c => c.CreatedAt);
    }
}