using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NTT.Contract.ScrapingData;
using NTT.Model.ScrapingData;

namespace NTT.API.StorageData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawingDataController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRealEstateBusiness _realEstateBusiness;
        public DrawingDataController(ILogger<WeatherForecastController> logger,
            IRealEstateBusiness realEstateBusiness)
        {
            _logger = logger;
            _realEstateBusiness = realEstateBusiness;
        }

        [HttpGet]
        public IEnumerable<DrawingDataModel> GetAll()
        {
            return _realEstateBusiness.GetAllDrawingData();
        }

        [HttpPost]
        public ActionResult StoreDrawingData(IEnumerable<DrawingDataModel> drawingData)
        {
          int insertedQuantity =  _realEstateBusiness.StoreDrawingData(drawingData);
           return CreatedAtAction(nameof(StoreDrawingData), new { totalInsert = insertedQuantity});
           // return Ok();
        }
    }
}