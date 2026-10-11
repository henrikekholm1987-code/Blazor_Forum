using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistence;

public class  ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions< ApplicationDbContext> options): base(options) { }
    public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
    public DbSet<ThreadItem> ThreadItems => Set<ThreadItem>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>()
            .HasKey(u => u.ApplicationUserId);

        modelBuilder.Entity<ApplicationUser>()
            .HasIndex(u => u.UserName)
            .IsUnique();

        modelBuilder.Entity<ThreadItem>()
            .HasKey(t => t.ThreadId);

        modelBuilder.Entity<ThreadItem>()
            .HasOne(t => t.ApplicationUser)
            .WithMany(u => u.Threads)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Comment>()
            .HasKey(c => c.CommentId);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.ApplicationUser)
            .WithMany(u => u.Comments)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.ThreadItem)
            .WithMany(t => t.Comments)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Comment>()
           .HasOne(c => c.ParentComment)
           .WithMany(c => c.Replies)
           .HasForeignKey(c => c.ParentCommentId)
           .IsRequired(false)
           .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Category>()
            .HasKey(c => c.CategoryId);

        modelBuilder.Entity<ThreadItem>()
            .HasOne(t => t.Category)
            .WithMany(c => c.Threads)
            .HasForeignKey(t => t.CategoryId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "General" },
            new Category { CategoryId = 2, Name = "Openings" },
            new Category { CategoryId = 3, Name = "Middlegame" },
            new Category { CategoryId = 4, Name = "Endgame" },
            new Category { CategoryId = 5, Name = "Tactics" });

    }
}