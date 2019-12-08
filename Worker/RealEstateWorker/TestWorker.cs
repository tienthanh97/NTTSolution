using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RealEstateWorker.Engines;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateWorker
{
    public class TestWorker : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //if (!stoppingToken.IsCancellationRequested)
            //{
            //    var scrapingEngine = new ScrapingEngine();
            //    //var config = scrapingEngine.GetConfig();
            //    //var json1 = JsonConvert.SerializeObject(config);
            //    var configs = scrapingEngine.GetConfignewStyle();
            //    var json1 = JsonConvert.SerializeObject(configs);
            //    var data = new Dictionary<string, List<Dictionary<string, string>>>();
            //    List<string> temdata = null;
            //    foreach (var cf in configs)
            //    {
            //        if (temdata!=null)
            //        {
            //            cf.SetDepentData(temdata);
            //        }
            //        cf.SetResponseData(data);
            //        cf.Execute();
            //        temdata = cf.GetCatchData();
            //    }
               
            //}

        }
    }
}
