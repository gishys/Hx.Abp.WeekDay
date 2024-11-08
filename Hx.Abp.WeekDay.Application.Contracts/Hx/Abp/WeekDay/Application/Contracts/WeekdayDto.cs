using Hx.Abp.WeekDay.Domain.Shared;

namespace Hx.Abp.WeekDay.Application.Contracts
{
    public class WeekdayDto
    {
        /// <summary>
        /// 年
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// 月
        /// </summary>
        public int Month { get; set; }
        /// <summary>
        /// 日
        /// </summary>
        public int Day { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime AdjustmentDate { get; set; }
        /// <summary>
        /// 描述信息
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// 工作调整类型
        /// </summary>
        public WeekdayAdjustmentType AdjustmentType { get; set; }
        /// <summary>
        /// 调整机构
        /// </summary>
        public WorkdayAdjustmentOrganization AdjustmentOrganization { get; set; }
    }
}
