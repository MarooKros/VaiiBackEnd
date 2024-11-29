using Microsoft.EntityFrameworkCore;
using VaibackEnd.Models;

namespace VaibackEnd.Data
{
    public class UserDbContext : DbContext
    {

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
