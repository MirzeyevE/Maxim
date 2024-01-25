using Maxim.Models;
using Microsoft.EntityFrameworkCore;

namespace Maxim.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) { }
        
        public DbSet<Service> Services { get; set; }
    }
}
