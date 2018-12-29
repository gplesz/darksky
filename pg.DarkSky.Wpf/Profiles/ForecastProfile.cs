using AutoMapper;
using pg.DarkSky.api.Model.FromDarkSky;
using pg.DarkSky.Wpf.Models;
using pg.DarkSky.Wpf.ViewModels;
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

            CreateMap<ForecastModelDataPoint, ForecastViewModel>()
                //csak olvasható property-k a megjelenítéshez, nem kell mappelni
                .ForMember(d => d.WeatherIcon, o => o.Ignore())
                .ForMember(d => d.WindspeedIcon, o => o.Ignore());
            ;
            

            CreateMap<ForecastModel, MainViewModel>()
                .ForMember(d => d.HasSuccess, o => o.MapFrom(s => s.IsValid))
                .ForMember(d => d.ForecastApiCalls, o => o.MapFrom(s => s.ForecastApiCalls))
                //ezek automatikusan mappelődnek
                //.ForMember(d => d.Current, o => o.MapFrom(s => s.Current))
                //.ForMember(d => d.Daily, o => o.MapFrom(s => s.Daily))
                //ezeket nem az api hívás tölti
                .ForMember(d => d.IsBusy, o => o.Ignore())
                .ForMember(d => d.RefreshDataCommand, o => o.Ignore())
                .ForMember(d => d.SelectableCity, o => o.Ignore())
                .ForMember(d => d.SelectedCity, o => o.Ignore())
                .ForMember(d => d.SelectableLanguage, o => o.Ignore())
                .ForMember(d => d.SelectedLanguage, o => o.Ignore())
                .ForMember(d => d.SettingsViewModel, o => o.Ignore())
                .ForMember(d => d.ErrorMessage, o => o.Ignore())
                ;
        }

        private static DateTimeOffset FromUnixTimeToDateTime(long time)
        {
            return DateTimeOffset.FromUnixTimeSeconds(time);
        }
    }
}
