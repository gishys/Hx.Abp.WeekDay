using Hx.Abp.WeekDay.Domain.Shared;
using Volo.Abp.DependencyInjection;

namespace Hx.Abp.WeekDay.Domain
{
    public interface IWeekdayManager : ITransientDependency
    {
        /// <summary>
        /// 获取工作日
        /// </summary>
        /// <param name="span">时间跨度（包含当天）</param>
        /// <param name="notIncludedHolidy">是否包含节假日</param>
        /// <returns></returns>
        Task<List<DateTime>> GetWeekDays(int span, bool notIncludedHolidy = true, string dateTimeFormat = "d");
        /// <summary>
        /// 创建工作日
        /// </summary>
        /// <param name="date"></param>
        /// <param name="description"></param>
        /// <param name="adjustmentOrganization"></param>
        /// <returns></returns>
        Task<Weekday> CreateAsync(
            DateTime date,
            string? description = null,
            WorkdayAdjustmentOrganization adjustmentOrganization = WorkdayAdjustmentOrganization.OwnOrganization);
        /// <summary>
        /// 修改工作日调整（1、增加工作日调整；2、删除工作日调整）
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<bool> ModifyDayStatusAsync(DateTime date);
        /// <summary>
        /// 通过年份获取工作日
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        Task<List<WorkdayOrHlidayDo>> GetWeekDaysByYearAsync(int year = 0);
    }
}