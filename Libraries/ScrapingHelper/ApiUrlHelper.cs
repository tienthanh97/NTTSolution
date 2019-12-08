using NTT.ScrapingLib.Model.ScrapingConfig.Execute;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NTT.ScrapingLib.ScrapingHelper
{
    public class ApiUrlHelper : IScrapingHelper
    {
        string _document;
        RequestHelper _scrape;

      
        public ApiUrlHelper(string document)
        {
            _document = document;
            _scrape = new RequestHelper();
         
        }
        public Dictionary<string, string> ScrapeData(ExecuteConfig executeConfig)
        {
            var result = new Dictionary<string, string>();
            try
            {
                string docResult = "";
                var config = (NavigateExecuteConfig)executeConfig;
                string url = config.CanNavigateByDoc ? _document : executeConfig.Pattern;
            
                if(config.HeaderConfigs!=null && config.HeaderConfigs.Any())
                {
                    docResult = _scrape.GetDocumentWithHeader(url,config.HeaderConfigs, executeConfig.Interval);
                }
                else
                {
                    docResult = _scrape.GetDocument(url, executeConfig.Interval);
                }
                 
                string key = Guid.NewGuid().ToString();
                result.Add(key, docResult);
            }
            catch (Exception ex)
            {

            }
           
           
            return result;
        }
    }
}
