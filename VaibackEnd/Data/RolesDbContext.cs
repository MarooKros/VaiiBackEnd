using Microsoft.EntityFrameworkCore;
using VaibackEnd.Models;

namespace VaibackEnd.Data
{
    public class RolesDbContext : DbContext
    {
        public RolesDbContext(DbContextOptions<RolesDbContext> options) : base(options) { }

        public DbSet<Roles> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}