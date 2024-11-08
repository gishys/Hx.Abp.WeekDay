using Volo.Abp.Application.Services;

namespace Hx.Abp.WeekDay.Application
{
    public class ReservationAppServiceBase : ApplicationService
    {
        public ReservationAppServiceBase()
        {
            ObjectMapperContext = typeof(HxAbpWeekDayApplicationModule);
        }
    }
}
