﻿using Hx.Abp.WeekDay.Domain.Shared;

namespace Hx.Abp.WeekDay.Application.Contracts
{
    public interface IWeekdayAppService
    {
        /// <summary>
        /// 通过年份获取节假日
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        Task<List<WorkdayOrHlidayDto>> GetHolidaysByYearAsync(int year = 0);
        /// <summary>
        /// 修改工作日调整（1、增加工作日调整；2、删除工作日调整）
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<bool> ModifyDayStatusAsync(DateTime date);
        /// <summary>
        /// 获取工作日
        /// </summary>
        /// <param name="date"></param>
        /// <param name="description"></param>
        /// <param name="adjustmentOrganization"></param>
        /// <returns></returns>
        Task<WeekdayDto> CreateAsync(
            DateTime date,
            string? description = null,
            WorkdayAdjustmentOrganization adjustmentOrganization = WorkdayAdjustmentOrganization.OwnOrganization);
        /// <summary>
        /// 根据输入时间计算工作日截止时间
        /// </summary>
        /// <param name="time">输入时间</param>
        /// <param name="span">时间跨度</param>
        /// <returns></returns>
        Task<DateTime> GetDeadlineTimeAsync(DateTime time, int span);
    }
}