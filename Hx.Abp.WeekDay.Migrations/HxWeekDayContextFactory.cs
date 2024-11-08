using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Hx.Workflow.EntityFrameworkCore.DbMigrations
{
    public class HxWeekDayContextFactory : IDesignTimeDbContextFactory<HxWeekDayContext>
    {
        public HxWeekDayContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();
            var builder =
                new DbContextOptionsBuilder<HxWeekDayContext>()
                .UseNpgsql(
                configuration.GetConnectionString("HxWeekDay"));
            return new HxWeekDayContext(builder.Options);
        }
        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
