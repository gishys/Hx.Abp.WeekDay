using Volo.Abp.Domain.Repositories;

namespace Hx.Abp.WeekDay.Domain
{
    public interface IWeekdayRepository : IBasicRepository<Weekday, Guid>
    {
        /// <summary>
        /// 通过年份获得工作日调整
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        Task<List<Weekday>> GetAdjustmentByYearAsync(int year, CancellationToken cancellationToken = default);
        /// <summary>
        /// 通过月份获取工作日调整
        /// </summary>
        /// <param name="month"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<Weekday>> GetAdjustmentByMonthAsync(int month, CancellationToken cancellationToken = default);
        /// <summary>
        /// 通过日期获取调整记录
        /// </summary>
        /// <param name="date"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Weekday?> GetAdjustmentByDateAsync(
            DateTime date,
            CancellationToken cancellationToken = default);
    }
}