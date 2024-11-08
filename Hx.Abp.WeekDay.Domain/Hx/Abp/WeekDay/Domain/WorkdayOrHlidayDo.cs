using Hx.Abp.WeekDay.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hx.Abp.WeekDay.Domain
{
    public class WorkdayOrHlidayDo
    {
        public WorkdayOrHlidayDo(
            string dateTime,
            int week,
            WeekdayAdjustmentType adjustmentType = WeekdayAdjustmentType.None)
        {
            DateTime = dateTime;
            Week = week;
            AdjustmentType = adjustmentType;
        }
        public string DateTime { get; set; }
        public WeekdayAdjustmentType AdjustmentType { get; set; }
        public int Week { get; set; }
    }
}