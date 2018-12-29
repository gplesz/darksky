using AutoMapper;
using pg.DarkSky.api.Model;
using pg.DarkSky.api.Service;
using pg.DarkSky.Wpf.Models;
using pg.DarkSky.Wpf.Profiles;
using pg.DarkSky.Wpf.Properties;
using Serilog;

namespace pg.DarkSky.Wpf.ViewModels
{
    public static class ViewModelLocator
    {
        private static readonly IOptions<ServiceOptions> Options;

        static ViewModelLocator()
        {
            Options = new Options<ServiceOptions>(new ServiceOptions(Settings.Default.APIKey));
        }

        public static void SetApiKey(string apiKey)
        {
            //todo: ezt mediator-ral ki lehetne váltani
            Options.Value.ApiKey = apiKey;
        }

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
                var service = new RequestService(Options, logger);

                var repository = new ForecastRepository(service, mapper);

                return new MainViewModel(repository, mapper,logger);
            }
        }
    }
}
