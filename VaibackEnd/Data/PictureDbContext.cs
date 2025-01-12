using Microsoft.EntityFrameworkCore;
using VaibackEnd.Models;

namespace VaibackEnd.Data
{
    public class PictureDbContext : DbContext
    {
        public PictureDbContext(DbContextOptions<PictureDbContext> options) : base(options) { }

        public DbSet<Picture> Pictures { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

