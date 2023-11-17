using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<WebUser> WebUsers { get; set; }

    }
}
