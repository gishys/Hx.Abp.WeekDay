using Hx.Abp.WeekDay.Domain;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hx.Abp.WeekDay.EntityFrameworkCore
{
    public class WeekdayRepository :
        EfCoreRepository<WeekDayDbContext, Weekday, Guid>,
        IWeekdayRepository
    {
        public WeekdayRepository(
            IDbContextProvider<WeekDayDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        /// <summary>
        /// 通过年份获取工作日调整
        /// </summary>
        /// <param name="year"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<Weekday>> GetAdjustmentByYearAsync(
            int year,
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .Where(p => p.Year == year)
                .ToListAsync(cancellationToken);
        }
        /// <summary>
        /// 通过月份获取工作日调整
        /// </summary>
        /// <param name="month"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<Weekday>> GetAdjustmentByMonthAsync(
            int month,
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .Where(p => p.Month == month)
                .ToListAsync(cancellationToken);
        }
        /// <summary>
        /// 通过日期获取调整记录
        /// </summary>
        /// <param name="date"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Weekday?> GetAdjustmentByDateAsync(
            DateTime date,
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .Where(p => p.AdjustmentDate == date)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}