using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NTT.Contract.ScrapingData;
using RealEstateWorker.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateWorker
{
    public class ScrapingCustomerWorker : BackgroundService
    {

        private readonly ILogger<DrawingDataWorker> _logger;

        private IRealEstateBusiness _realEstateBusiness;
        private ICustomerScrapingBusiness _customerScrapingBusiness;
        public IConfiguration _configuration { get; }
        public ScrapingCustomerWorker(
            ILogger<DrawingDataWorker> logger,
            IConfiguration configuration,
            IRealEstateBusiness realEstateBusiness,
            ICustomerScrapingBusiness customerScrapingBusiness)
        {
            _logger = logger;
            _configuration = configuration;
            _realEstateBusiness = realEstateBusiness;
            _customerScrapingBusiness = customerScrapingBusiness;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (!stoppingToken.IsCancellationRequested)
            {
                while (true)
                {
                    var data = _realEstateBusiness.Gettop100DrawingData();
                    if (data != null && data.Any())
                    {
                        var scrapingengine = new ScrapingEngine();
                        var configs = scrapingengine.GetScrapingConfigByFile("ScrapingCustomerWorkerr_Config.json");
                        var config = configs.First();
                        var dependData = data.Select(x => x.Data).ToList();
                        config.SetDepentData(dependData);
                        var scrapingresult = new Dictionary<string, List<Dictionary<string, string>>>();
                        scrapingengine.RunScraping(scrapingresult, config);

                        if (scrapingresult != null && scrapingresult.Any())
                        {
                            var result = scrapingengine.ConvertCustomerData(scrapingresult);
                            var insertResult = _customerScrapingBusiness.StoreCustomerData(result);
                            var updatestatusResult = _realEstateBusiness.UpdateDrawingStatus(data.Select(x => x.Id).ToList());
                        }
                    }
                    else
                    {
                        break;
                    }
                }
               
                
            }
                

        }

    }
}
