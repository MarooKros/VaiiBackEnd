using Microsoft.EntityFrameworkCore;
using VaibackEnd.Models;

namespace VaibackEnd.Data
{
    public class IssueDbContext : DbContext
    {

        public IssueDbContext(DbContextOptions<IssueDbContext> options) : base(options)
        {  
        }

        public DbSet<Issue> Issues { get; set; }
    }
}
