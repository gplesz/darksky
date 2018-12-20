using AutoMapper;
using pg.DarkSky.api.Model.FromDarkSky;
using pg.DarkSky.Wpf.Models;
using System;

namespace pg.DarkSky.Wpf.Profiles
{
    public class ForecastProfile : Profile
    {
        public ForecastProfile()
        {
            CreateMap<CurrentlyDataPoint, ForecastModelDataPoint>()
                //todo: az időzónát még használni kéne
                .ForMember(d => d.Time, o => o.MapFrom(s => FromUnixTimeToDateTime(s.time)))
                //ez jó így?
                .ForMember(d => d.AtmosphericPressure, o => o.MapFrom(s =>s.pressure))
                ;

            CreateMap<DailyDataPoint, ForecastModelDataPoint>()
                .ForMember(d => d.Time, o => o.MapFrom(s => FromUnixTimeToDateTime(s.time)))
                //todo: ezt még kidolgozni
                .ForMember(d => d.Temperature, o => o.MapFrom(s => (s.temperatureHigh / 2 + s.temperatureLow / 2)))
                .ForMember(d => d.ApparentTemperature, o => o.MapFrom(s => (s.apparentTemperatureLow / 2 + s.apparentTemperatureHigh / 2)))
                .ForMember(d => d.AtmosphericPressure, o => o.MapFrom(s => s.pressure))
                ;

            CreateMap<api.Model.ApiResult<ApiResponse>, ForecastModel>()
                .ForMember(d => d.IsValid, o => o.MapFrom(s => s.HasSuccess))
                .ForMember(d => d.Current, o => o.MapFrom(s => s.Data.currently))
                .ForMember(d => d.Daily, o => o.MapFrom(s => s.Data.daily.data));
        }

        private static DateTimeOffset FromUnixTimeToDateTime(long time)
        {
            return DateTimeOffset.FromUnixTimeSeconds(time);
        }
    }
}
