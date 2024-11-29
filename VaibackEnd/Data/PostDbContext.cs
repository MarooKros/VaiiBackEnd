using Microsoft.EntityFrameworkCore;
using VaibackEnd.Models;

public class PostDbContext : DbContext
{
    public PostDbContext(DbContextOptions<PostDbContext> options) : base(options) { }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Post>()
            .HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .IsRequired();

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(c => c.UserId)
            .IsRequired();

        modelBuilder.Entity<User>().ToTable("Users", schema: "dbo");
    }
}