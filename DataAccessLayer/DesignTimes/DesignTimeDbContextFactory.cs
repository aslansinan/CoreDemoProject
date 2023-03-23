using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccessLayer.DesignTimes;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Context>
{
    public Context CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<Context> optionsBuilder = new();
        optionsBuilder.UseSqlServer(
            "server=.;database=CoreBlogDb;integrated security = true; Trust Server Certificate=true");
        return new Context(optionsBuilder.Options);
    }
}