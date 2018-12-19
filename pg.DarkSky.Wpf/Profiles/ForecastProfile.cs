using AutoMapper;
using pg.DarkSky.api.Model.FromDarkSky;
using pg.DarkSky.Wpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg.DarkSky.Wpf.Profiles
{
    public class ForecastProfile : Profile
    {
        public ForecastProfile()
        {
            CreateMap<CurrentlyDataPoint, ForecastModelDataPoint>();

            CreateMap<DailyDataPoint, ForecastModelDataPoint>();

            CreateMap<api.Model.ApiResult<ApiResponse>, ForecastModel>()
                .ForMember(d => d.IsValid, o => o.MapFrom(s => s.HasSuccess))
                .ForMember(d => d.Current, o => o.MapFrom(s => s.Data.currently))
                .ForMember(d => d.Daily, o => o.MapFrom(s => s.Data.daily.data));
        }
    }
}
