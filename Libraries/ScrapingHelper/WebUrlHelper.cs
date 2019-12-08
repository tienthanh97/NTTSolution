
namespace NTT.ScrapingLib.ScrapingHelper
{
    using NTT.ScrapingLib.Model.ScrapingConfig.Execute;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class WebUrlHelper : IScrapingHelper
    {
        private string _document;
        private RequestHelper _scrape;
        public WebUrlHelper(string document)
        {
            _document = document;
            _scrape = new RequestHelper();
        }

        public Dictionary<string, string> ScrapeData(ExecuteConfig executeConfig)
        {
            var result = new Dictionary<string, string>();
            try
            {
                var config =(NavigateExecuteConfig) executeConfig;
                string url = config.CanNavigateByDoc? _document : executeConfig.Pattern;
                var docResult = "";
                if (config.HeaderConfigs != null && config.HeaderConfigs.Any())
                {
                    docResult = _scrape.GetDocumentWithHeader(url, config.HeaderConfigs, executeConfig.Interval);
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
