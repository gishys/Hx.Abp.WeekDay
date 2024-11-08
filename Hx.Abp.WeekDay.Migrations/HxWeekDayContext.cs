using Hx.Abp.WeekDay.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hx.Workflow.EntityFrameworkCore.DbMigrations
{
    public class HxWeekDayContext(
        DbContextOptions<HxWeekDayContext> options) : AbpDbContext<HxWeekDayContext>(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WeekdayEntityTypeConfiguration).Assembly);
        }
    }
}
