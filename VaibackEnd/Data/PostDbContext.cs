using Microsoft.EntityFrameworkCore;
using VaibackEnd.Models;

namespace VaibackEnd.Data
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}
