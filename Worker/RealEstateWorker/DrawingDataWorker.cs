using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NTT.Model.ScrapingData;
using RealEstateWorker.Engines;

namespace RealEstateWorker
{
    public class DrawingDataWorker : BackgroundService
    {
        private readonly ILogger<DrawingDataWorker> _logger;
        public IConfiguration _configuration { get; }

        public DrawingDataWorker(ILogger<DrawingDataWorker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Start Scraping ..................");
                ScrapingEngine scrapingEngine = new ScrapingEngine();
                var data = new Dictionary<string, List<Dictionary<string, string>>>();
                var configs = scrapingEngine.GetScrapingConfigByFile("DrawingDataWorker_Config.json");
                foreach (var config in configs)
                {
                    scrapingEngine.RunScraping(data, config);
                    if (data != null && data.Any())
                    {
                        var result = scrapingEngine.ConvertData(data);
                        StorageData(result.ToList());
                    }
                }
                _logger.LogInformation("Scraping Stopped........................");
            }
        }

        private void StorageData(List<DrawingDataModel> data)
        {
            foreach (var item in data)
            {
                item.BusinessId = 1;
            }
            var apihandler = new ApiHandler(_configuration["Scraping:StorageServer"]);
            string actionLink = _configuration["Scraping:StorageURL"];
            var jsonData = JsonConvert.SerializeObject(data);
            apihandler.SendPost(jsonData, actionLink).Wait();

        }
    }
}
