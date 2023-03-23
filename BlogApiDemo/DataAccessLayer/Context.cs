using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccessLayer;

public class Context : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=.;database=CoreBlogApiDb;integrated security = true; Trust Server Certificate=true");
    }
    
    public DbSet<Employee> Employees { get; set; }
} 