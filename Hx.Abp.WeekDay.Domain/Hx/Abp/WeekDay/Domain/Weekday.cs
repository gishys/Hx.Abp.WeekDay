using Hx.Abp.WeekDay.Domain.Shared;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hx.Abp.WeekDay.Domain
{
    public class Weekday : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 年
        /// </summary>
        public virtual int Year { get; protected set; }
        /// <summary>
        /// 月
        /// </summary>
        public virtual int Month { get; protected set; }
        /// <summary>
        /// 日
        /// </summary>
        public virtual int Day { get; protected set; }
        /// <summary>
        /// 日期
        /// </summary>
        public virtual DateTime AdjustmentDate { get; protected set; }
        /// <summary>
        /// 描述信息
        /// </summary>
        public virtual string? Description { get; protected set; }
        /// <summary>
        /// 工作调整类型
        /// </summary>
        public virtual WeekdayAdjustmentType AdjustmentType { get; protected set; }
        /// <summary>
        /// 调整机构
        /// </summary>
        public virtual WorkdayAdjustmentOrganization AdjustmentOrganization { get; protected set; }
        public Weekday()
        { }
        public Weekday(
            int year,
            int month,
            int day,
            DateTime adjustmentDate,
            string? description,
            WeekdayAdjustmentType weekdayAdjustmentType,
            WorkdayAdjustmentOrganization adjustmentOrganization)
        {
            Year = year;
            Month = month;
            Day = day;
            AdjustmentDate = adjustmentDate;
            Description = description;
            AdjustmentType = weekdayAdjustmentType;
            AdjustmentOrganization = adjustmentOrganization;
        }
    }
}
