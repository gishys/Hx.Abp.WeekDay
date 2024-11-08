using Hx.Abp.WeekDay.Domain;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hx.Abp.WeekDay.EntityFrameworkCore
{
    [ConnectionStringName("HxWeekDay")]
    public class WeekDayDbContext(DbContextOptions<WeekDayDbContext> options) : AbpDbContext<WeekDayDbContext>(options)
    {
        public virtual DbSet<Weekday> Weekdays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WeekdayEntityTypeConfiguration).Assembly);
        }
    }
}