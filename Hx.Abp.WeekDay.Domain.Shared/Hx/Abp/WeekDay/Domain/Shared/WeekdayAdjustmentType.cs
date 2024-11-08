using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hx.Abp.WeekDay.Domain.Shared
{
    /// <summary>
    /// 工作日调整
    /// </summary>
    public enum WeekdayAdjustmentType
    {
        /// <summary>
        /// 调入-周末为工作日
        /// </summary>
        Into = 1,
        /// <summary>
        /// 调出-非周末休息日
        /// </summary>
        Out = 2,
        /// <summary>
        /// 无
        /// </summary>
        None = 9
    }
}
