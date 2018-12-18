using AutoMapper;
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
            CreateMap<api.Model.ApiResult<api.Model.FromDarkSky.ApiResponse>, ForecastModel>();
        }
    }
}
