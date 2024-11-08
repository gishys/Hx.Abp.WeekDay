using AutoMapper;
using Hx.Abp.WeekDay.Application.Contracts;
using Hx.Abp.WeekDay.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hx.Abp.WeekDay.Application
{
    public class WeekDayProfile : Profile
    {
        public WeekDayProfile()
        {
            CreateMap<WorkdayOrHlidayDo, WorkdayOrHlidayDto>(MemberList.None);
            CreateMap<Weekday, WeekdayDto>(MemberList.None);
        }
    }
}
