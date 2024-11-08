using Hx.Abp.WeekDay.Domain.Shared;

namespace Hx.Abp.WeekDay.Application.Contracts
{
    public class WorkdayOrHlidayDto(
        string dateTime,
        int week,
        WeekdayAdjustmentType adjustmentType = WeekdayAdjustmentType.None)
    {
        public string DateTime { get; set; } = dateTime;
        public WeekdayAdjustmentType AdjustmentType { get; set; } = adjustmentType;
        public int Week { get; set; } = week;
    }
}