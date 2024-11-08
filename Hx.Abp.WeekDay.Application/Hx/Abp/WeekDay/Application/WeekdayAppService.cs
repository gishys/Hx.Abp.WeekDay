using Hx.Abp.WeekDay.Application.Contracts;
using Hx.Abp.WeekDay.Domain;
using Hx.Abp.WeekDay.Domain.Shared;

namespace Hx.Abp.WeekDay.Application
{
    public class WeekdayAppService(IWeekdayManager weekdayManager) : ReservationAppServiceBase, IWeekdayAppService
    {
        private readonly IWeekdayManager _weekdayManager = weekdayManager;

        /// <summary>
        /// 通过年份获取工作日
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public virtual async Task<List<WorkdayOrHlidayDto>> GetWeekDaysByYearAsync(int year = 0)
        {
            return ObjectMapper.Map<List<WorkdayOrHlidayDo>, List<WorkdayOrHlidayDto>>(await _weekdayManager.GetWeekDaysByYearAsync(year));
        }
        /// <summary>
        /// 修改工作日调整（1、增加工作日调整；2、删除工作日调整）
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public virtual async Task<bool> ModifyDayStatusAsync(DateTime date)
        {
            return await _weekdayManager.ModifyDayStatusAsync(date);
        }
        /// <summary>
        /// 创建工作日
        /// </summary>
        /// <param name="date"></param>
        /// <param name="description"></param>
        /// <param name="adjustmentOrganization"></param>
        /// <returns></returns>
        public virtual async Task<WeekdayDto> CreateAsync(
            DateTime date,
            string? description = null,
            WorkdayAdjustmentOrganization adjustmentOrganization = WorkdayAdjustmentOrganization.OwnOrganization)
        {
            return ObjectMapper.Map<Weekday, WeekdayDto>(await _weekdayManager.CreateAsync(date, description, adjustmentOrganization));
        }
    }
}