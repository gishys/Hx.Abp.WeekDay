using Hx.Abp.WeekDay.Application.Contracts;
using Hx.Abp.WeekDay.Domain.Shared;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Nm.Reservation
{
    /// <summary>
    /// 工作日
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <param name="appService"></param>
    [ApiController]
    [Route("api/weekday")]
    public class WeekdayController(IWeekdayAppService appService) : AbpController
    {
        private readonly IWeekdayAppService _appService = appService;

        /// <summary>
        /// 通过年份获取工作日
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{year}")]
        public Task<List<WorkdayOrHlidayDto>> GetWeekDaysByYearAsync(int year = 0)
        {
            return _appService.GetWeekDaysByYearAsync(year);
        }
        /// <summary>
        /// 修改工作日调整（1、增加工作日调整；2、删除工作日调整）
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{date}")]
        public Task<bool> ModifyDayStatusAsync(DateTime date)
        {
            return _appService.ModifyDayStatusAsync(date);
        }
        /// <summary>
        /// 创建工作日
        /// </summary>
        /// <param name="date"></param>
        /// <param name="description"></param>
        /// <param name="adjustmentOrganization"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<WeekdayDto> CreateAsync(
            DateTime date,
            string? description = null,
            WorkdayAdjustmentOrganization adjustmentOrganization = WorkdayAdjustmentOrganization.OwnOrganization)
        {
            return _appService.CreateAsync(date, description, adjustmentOrganization);
        }
    }
}