using Hx.Abp.WeekDay.Domain.Shared;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Hx.Abp.WeekDay.Domain
{
    [DependsOn(typeof(AbpDddDomainModule))]
    [DependsOn(typeof(HxAbpWeekDayDomainSharedModule))]
    public class HxAbpWeekDayDomainModule : AbpModule
    {

    }
}
