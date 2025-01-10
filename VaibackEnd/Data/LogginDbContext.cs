using Microsoft.EntityFrameworkCore;
using VaibackEnd.Models;

namespace VaibackEnd.Data
{
    public class LogginDbContext : DbContext
    {
        public LogginDbContext(DbContextOptions<LogginDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
