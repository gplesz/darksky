using pg.DarkSky.api.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg.DarkSky.Wpf.Models
{
    public class ForecastModel
    {
        private readonly RequestService requestService;

        public ForecastModel(RequestService requestService)
        {
            this.requestService = requestService ?? throw new ArgumentNullException(nameof(requestService));
        }

        
    }
}
