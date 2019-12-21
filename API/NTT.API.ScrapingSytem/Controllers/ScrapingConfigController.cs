using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NTT.Contract.ScrapingSystem;
using NTT.Model.ScrapingSystem;

namespace NTT.API.ScrapingSytem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrapingConfigController : ControllerBase
    {
        private readonly IScrapingConfigBusiness  _scrapingConfigBusiness;
        public ScrapingConfigController(IScrapingConfigBusiness scrapingConfigBusiness)
        {
            this._scrapingConfigBusiness = scrapingConfigBusiness;
        }

        [HttpGet]
        public IEnumerable<ScrapingConfigModel> GetConfig()
        {
            return _scrapingConfigBusiness.GetScrapingConfigInfo();
            
        }
    }
}