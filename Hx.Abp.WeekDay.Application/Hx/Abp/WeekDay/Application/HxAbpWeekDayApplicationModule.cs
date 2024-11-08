using Hx.Abp.WeekDay.Application.Contracts;
using Hx.Abp.WeekDay.Domain;
using Hx.Abp.WeekDay.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Hx.Abp.WeekDay.Application
{
    [DependsOn(typeof(AbpAutoMapperModule))]
    [DependsOn(typeof(HxAbpWeekDayDomainModule))]
    [DependsOn(typeof(HxAbpWeekDayEntityFrameworkCoreModule))]
    [DependsOn(typeof(HxAbpWeekDayApplicationContractsModule))]
    public class HxAbpWeekDayApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<HxAbpWeekDayApplicationModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<WeekDayProfile>(validate: true);
            });
        }
    }
}
