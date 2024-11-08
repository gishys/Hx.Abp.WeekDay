using Volo.Abp.Application;
using Volo.Abp.FluentValidation;
using Volo.Abp.Modularity;

namespace Hx.Abp.WeekDay.Application.Contracts
{
    [DependsOn(typeof(AbpDddApplicationModule))]
    [DependsOn(typeof(AbpFluentValidationModule))]
    public class HxAbpWeekDayApplicationContractsModule : AbpModule
    {
    }
}
