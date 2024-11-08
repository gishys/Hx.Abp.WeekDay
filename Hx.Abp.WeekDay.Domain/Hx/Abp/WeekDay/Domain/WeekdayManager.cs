using Hx.Abp.WeekDay.Domain.Shared;
using Volo.Abp;

namespace Hx.Abp.WeekDay.Domain
{
    public class WeekdayManager : IWeekdayManager
    {
        private readonly IWeekdayRepository _weekdayRepository;
        public WeekdayManager(
            IWeekdayRepository weekdayRepository)
        {
            _weekdayRepository = weekdayRepository;
        }
        /// <summary>
        /// 创建工作日
        /// </summary>
        /// <param name="date"></param>
        /// <param name="description"></param>
        /// <param name="weekdayAdjustmentType"></param>
        /// <param name="adjustmentOrganization"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        public async Task<Weekday> CreateAsync(
            DateTime date,
            string? description = null,
            WorkdayAdjustmentOrganization adjustmentOrganization = WorkdayAdjustmentOrganization.OwnOrganization)
        {
            int week = (int)date.DayOfWeek;
            var weekdayAdjustmentType = WeekdayAdjustmentType.Into;
            if (week != 0 && week != 6)
            {
                weekdayAdjustmentType = WeekdayAdjustmentType.Out;
            }
            var entity = new Weekday(
            date.Year,
            date.Month,
            date.Day,
            new DateTime(date.Year, date.Month, date.Day),
            description,
            weekdayAdjustmentType,
            adjustmentOrganization);
            return await _weekdayRepository.InsertAsync(entity);
        }
        /// <summary>
        /// 修改工作日调整（1、增加工作日调整；2、删除工作日调整）
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public async Task<bool> ModifyDayStatusAsync(DateTime date)
        {
            var entity = await _weekdayRepository.GetAdjustmentByDateAsync(date);
            if (entity == null)
            {
                await CreateAsync(date);
            }
            else
            {
                await _weekdayRepository.DeleteAsync(entity.Id);
            }
            return true;
        }
        /// <summary>
        /// 通过年份获取工作日
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public async Task<List<WorkdayOrHlidayDo>> GetWeekDaysByYearAsync(int year = 0)
        {
            var list = new List<WorkdayOrHlidayDo>();
            year = year == 0 ? DateTime.Now.Year : year;
            var ajustmentList = await _weekdayRepository.GetAdjustmentByYearAsync(year);
            var nextYear = (new DateTime(year, 1, 1)).AddYears(1);
            var currentDate = new DateTime(year, 1, 1);
            while (currentDate < nextYear)
            {
                var week = (int)currentDate.DayOfWeek;
                if (ajustmentList.Any(d => d.AdjustmentDate == currentDate && d.AdjustmentType == WeekdayAdjustmentType.Into))
                {
                    currentDate = currentDate.AddDays(1);
                    continue;
                }
                if (ajustmentList.Any(d => d.AdjustmentDate == currentDate && d.AdjustmentType == WeekdayAdjustmentType.Out))
                {
                    list.Add(new WorkdayOrHlidayDo(currentDate.ToShortDateString(), week, WeekdayAdjustmentType.Into));
                    currentDate = currentDate.AddDays(1);
                    continue;
                }
                if (week == 0 || week == 6)
                {
                    list.Add(new WorkdayOrHlidayDo(currentDate.ToShortDateString(), week));
                }
                currentDate = currentDate.AddDays(1);
            }
            return list;
        }
        /// <summary>
        /// 获取工作日
        /// </summary>
        /// <param name="span">时间跨度（包含当天）</param>
        /// <param name="notIncludedHolidy">是否包含节假日</param>
        /// <returns></returns>
        public async Task<List<DateTime>> GetWeekDays(int span, bool notIncludedHolidy = true, string dateTimeFormat = "d")
        {
            var list = new List<DateTime>();
            var currentDate = DateTime.Now;
            var ajustmentList = await _weekdayRepository.GetAdjustmentByYearAsync(currentDate.Year);
            int sumDay = 1;
            int addDay = 1;
            if (notIncludedHolidy)
            {
                sumDay--;
                span--;
                addDay--;
            }
            while (sumDay <= span)
            {
                var ajustmentDate = Convert.ToDateTime(currentDate.ToString(dateTimeFormat)).AddDays(addDay);
                if (await IsWorkDayAsync(ajustmentDate, ajustmentList))
                {
                    list.Add(ajustmentDate);
                    sumDay++;
                }
                addDay++;
            }
            return list;
        }
        /// <summary>
        /// 判断是否为工作日
        /// </summary>
        /// <param name="currentDT"></param>
        /// <param name="wDays"></param>
        /// <returns></returns>
        public virtual async Task<bool> IsWorkDayAsync(DateTime currentDT, List<Weekday> wDays)
        {
            if (!wDays.Any(d => d.Year == currentDT.Year))
            {
                wDays = await _weekdayRepository.GetAdjustmentByYearAsync(currentDT.Year);
            }
            if (wDays.Count > 0)
            {
                //非周末休息日
                string date = currentDT.ToString("MMdd");
                if (wDays.Any(d => $"{d.Month.ToString().PadLeft(2, '0')}{d.Day.ToString().PadLeft(2, '0')}" == date
                && d.AdjustmentType == WeekdayAdjustmentType.Out))
                {
                    return false;
                }
                //周末为工作日
                if (wDays.Any(d => $"{d.Month.ToString().PadLeft(2, '0')}{d.Day.ToString().PadLeft(2, '0')}" == date
                && d.AdjustmentType == WeekdayAdjustmentType.Into))
                {
                    return true;
                }
            }
            //正常工作日
            int week = (int)currentDT.DayOfWeek;
            if (week != 0 && week != 6)
                return true;
            return false;
        }
    }
}