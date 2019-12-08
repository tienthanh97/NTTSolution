using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NTT.Contract.ScrapingData;
using NTT.Model.ScrapingData;

namespace NTT.API.StorageData.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRealEstateBusiness _realEstateBusiness;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IRealEstateBusiness realEstateBusiness)
        {
            _logger = logger;
            _realEstateBusiness = realEstateBusiness;
        }

      
    }
}
