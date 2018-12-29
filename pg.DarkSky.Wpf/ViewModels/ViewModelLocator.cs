using AutoMapper;
using pg.DarkSky.api.Service;
using pg.DarkSky.Wpf.Models;
using pg.DarkSky.Wpf.Profiles;
using pg.DarkSky.Wpf.Properties;
using Serilog;

namespace pg.DarkSky.Wpf.ViewModels
{
    public static class ViewModelLocator
    {
        public static MainViewModel MainViewModel
        {
            get
            {
                var logger = Log.Logger;
                var mapper = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<ForecastProfile>();
                }).CreateMapper();

                //todo: apikey a beállításokból jöjjön
                var service = new RequestService(Settings.Default.APIKey, logger);

                var repository = new ForecastRepository(service, mapper);

                return new MainViewModel(repository, mapper,logger);
            }
        }
    }
}
