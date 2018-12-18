using AutoMapper;
using pg.DarkSky.api.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg.DarkSky.Wpf.Models
{
    public class ForecastRepository
    {
        private readonly RequestService requestService;
        private readonly IMapper mapper;

        public ForecastRepository(RequestService requestService, IMapper mapper)
        {
            this.requestService = requestService ?? throw new ArgumentNullException(nameof(requestService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public ForecastModel GetData()
        {
            var apiData = requestService.GetCurrentAndDailyData();
            return mapper.Map<ForecastModel>(apiData);
        }
    }
}
